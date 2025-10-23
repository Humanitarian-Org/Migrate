#nullable enable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace Medical.Domain.Managers.Services.CosmosService;

public sealed class CosmosRepository
{
    private readonly Container _container;

    public CosmosRepository(CosmosClient client, string databaseId, string containerId)
    {
        _container = client.GetContainer(databaseId, containerId);


    }

    static void Validate(CosmosItem i)
    {
        if (i is null) throw new ArgumentNullException(nameof(i));
        if (string.IsNullOrWhiteSpace(i.id)) throw new ArgumentException("Id must be provided.", nameof(i));
        if (string.IsNullOrWhiteSpace(i.CorrelationId)) throw new ArgumentException("CorrelationId must be provided.", nameof(i));
        if (string.IsNullOrWhiteSpace(i.DocType)) throw new ArgumentException("DocType must be provided.", nameof(i));
    }

    public Task<ItemResponse<T>> CreateAsync<T>(T item, CancellationToken ct = default)
        where T : CosmosItem
    {
        Validate(item);
        var debug = ToDebugJson(item);
        return _container.CreateItemAsync(item, new PartitionKey(item.CorrelationId), cancellationToken: ct);
    }

    public Task<ItemResponse<T>> UpsertAsync<T>(T item, CancellationToken ct = default)
        where T : CosmosItem
    {
        Validate(item);
        var debug = ToDebugJson(item);
        Console.WriteLine($"Upserting item: {debug}");
        var props = _container.ReadContainerAsync().GetAwaiter().GetResult();
        Console.WriteLine($"PK path = {props.Resource.PartitionKeyPath}");
        return _container.UpsertItemAsync(item, new PartitionKey(item.CorrelationId), cancellationToken: ct);
    }

    public Task<ItemResponse<T>> ReadAsync<T>(string id, string correlationId, CancellationToken ct = default)
        where T : CosmosItem
        => _container.ReadItemAsync<T>(id, new PartitionKey(correlationId), cancellationToken: ct);

    public Task<ItemResponse<T>> ReplaceAsync<T>(T item, string ifMatchEtag, CancellationToken ct = default)
        where T : CosmosItem
    {
        Validate(item);
        var opts = new ItemRequestOptions { IfMatchEtag = ifMatchEtag };
        return _container.ReplaceItemAsync(item, item.id, new PartitionKey(item.CorrelationId), opts, ct);
    }

    public Task<ItemResponse<dynamic>> DeleteAsync(string id, string correlationId, string? ifMatchEtag = null, CancellationToken ct = default)
    {
        var opts = new ItemRequestOptions { IfMatchEtag = ifMatchEtag };
        return _container.DeleteItemAsync<dynamic>(id, new PartitionKey(correlationId), opts, ct);
    }

    // Partition-scoped (cheap). Optionally enforce docType
    public async IAsyncEnumerable<T> QueryPartitionAsync<T>(
        string correlationId,
        bool enforceDocType = false,
        string? extraWhere = null,
        Dictionary<string, object>? parameters = null,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
        where T : CosmosItem
    {
        var where = enforceDocType ? "c.DocType = @docType" : "1=1";
        if (!string.IsNullOrWhiteSpace(extraWhere)) where += $" AND ({extraWhere})";

        var qd = new QueryDefinition($"SELECT * FROM c WHERE {where}");
        if (enforceDocType) qd = qd.WithParameter("@docType", typeof(T).Name); // if your DocType differs, change this line to use that mapping or literal
        if (parameters != null) foreach (var (k, v) in parameters) qd = qd.WithParameter(k, v);

        using var feed = _container.GetItemQueryIterator<T>(
            qd,
            requestOptions: new QueryRequestOptions { PartitionKey = new PartitionKey(correlationId) });

        while (!ct.IsCancellationRequested && feed.HasMoreResults)
            foreach (var item in await feed.ReadNextAsync(ct))
                yield return item;
    }

    // Cross-partition by docType (use sparingly)
    public async IAsyncEnumerable<T> QueryAllByDocTypeAsync<T>(
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
        where T : CosmosItem
    {
        var qd = new QueryDefinition("SELECT * FROM c WHERE c.DocType = @docType")
                 .WithParameter("@docType", typeof(T).Name);

        using var feed = _container.GetItemQueryIterator<T>(qd);
        while (!ct.IsCancellationRequested && feed.HasMoreResults)
            foreach (var item in await feed.ReadNextAsync(ct))
                yield return item;
    }

    // Optional: transactional batch (same partition)
    public async Task<TransactionalBatchResponse> BatchUpsertAsync<T>(string correlationId, IEnumerable<T> items, CancellationToken ct = default)
        where T : CosmosItem
    {
        var pk = new PartitionKey(correlationId);
        var batch = _container.CreateTransactionalBatch(pk);
        foreach (var it in items)
        {
            Validate(it);
            if (!string.Equals(it.CorrelationId, correlationId, StringComparison.Ordinal))
                throw new ArgumentException("All items in the batch must share the same CorrelationId.");
            batch.UpsertItem(it);
        }
        return await batch.ExecuteAsync(ct);
    }

    public async IAsyncEnumerable<T> QueryPartitionUnprocessedAsync<T>(
    string correlationId,
    bool enforceDocType = false,
    string? extraWhere = null,
    Dictionary<string, object>? parameters = null,
    [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
    where T : CosmosItem
    {
        var where = enforceDocType ? "c.DocType = @docType AND c.IsProcessed != @processed" : "c.IsProcessed != @processed";
        if (!string.IsNullOrWhiteSpace(extraWhere)) where += $" AND ({extraWhere})";

        var qd = new QueryDefinition($"SELECT * FROM c WHERE {where}")
                    .WithParameter("@processed", "1");

        if (enforceDocType) qd = qd.WithParameter("@docType", typeof(T).Name);
        if (parameters != null) foreach (var (k, v) in parameters) qd = qd.WithParameter(k, v);

        using var feed = _container.GetItemQueryIterator<T>(
            qd,
            requestOptions: new QueryRequestOptions { PartitionKey = new PartitionKey(correlationId) });

        while (!ct.IsCancellationRequested && feed.HasMoreResults)
            foreach (var item in await feed.ReadNextAsync(ct))
                yield return item;
    }
    public async Task<long> CountUnprocessedByDocTypeAsync(string correlationId, string docType, CancellationToken ct = default)
    {
        var qd = new QueryDefinition(
            "SELECT VALUE COUNT(1) FROM c WHERE c.DocType = @docType AND (NOT IS_DEFINED(c.IsProcessed) OR c.IsProcessed != @processed)")
            .WithParameter("@docType", docType)
            .WithParameter("@processed", "1");

        using var feed = _container.GetItemQueryIterator<long>(
            qd,
            requestOptions: new QueryRequestOptions { PartitionKey = new PartitionKey(correlationId) });

        while (!ct.IsCancellationRequested && feed.HasMoreResults)
        {
            var page = await feed.ReadNextAsync(ct);
            foreach (var v in page) return v;
        }

        return 0L;
    }
    public async Task<T?> GetFirstUnprocessedByDocTypeAsync<T>(string correlationId, string docType, CancellationToken ct = default)
           where T : CosmosItem
    {
        var qd = new QueryDefinition(
            "SELECT TOP 1 * FROM c WHERE c.DocType = @docType AND (NOT IS_DEFINED(c.IsProcessed) OR c.IsProcessed != @processed)")
            .WithParameter("@docType", docType)
            .WithParameter("@processed", "1");

        using var feed = _container.GetItemQueryIterator<T>(
            qd,
            requestOptions: new QueryRequestOptions { PartitionKey = new PartitionKey(correlationId), MaxItemCount = 1 });

        if (!ct.IsCancellationRequested && feed.HasMoreResults)
        {
            var page = await feed.ReadNextAsync(ct);
            foreach (var item in page) return item;
        }

        return default;
    }

    private static string ToDebugJson<T>(T item) =>
    System.Text.Json.JsonSerializer.Serialize(item, new System.Text.Json.JsonSerializerOptions
    {
        PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
        WriteIndented = true
    });
}