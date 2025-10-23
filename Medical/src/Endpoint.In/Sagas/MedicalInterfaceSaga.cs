using System.Threading.Tasks;
using NServiceBus;
using Microsoft.Extensions.Logging;
using Medical.Domain.Contracts.Events;
using Medical.Domain.Contracts.Commands;
using Medical.Domain.Contracts;
using System;

namespace Endpoint.In.Sagas
{
    public class MedicalInterfaceSaga : Saga<MedicalInterfaceSagaData>,
        IAmStartedByMessages<CaseRegistrationRequested>,
        IHandleMessages<CaseRegistrationCompleted>,
        IHandleMessages<CaseUpdateCompleted>,
        IHandleMessages<FinalizeCaseCompleted>,
        IHandleMessages<DeleteHealthCaseCompleted>,
        IHandleMessages<ScheduleCaseUpdateCheck>,
        IHandleTimeouts<HealthCaseStatusCheckIsDue>

    {
        private readonly ILogger<MedicalInterfaceSaga> _logger;

        public MedicalInterfaceSaga(ILogger<MedicalInterfaceSaga> logger)
        {
            _logger = logger;
        }

        public async Task Handle(CaseRegistrationRequested message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"[MedicalSaga] Saga started: Registration requested | CorrelationId: {message.CorrelationId}");
            Data.DocId = message.DocId;
            Data.CorrelationId = message.CorrelationId;

            await context.SendLocal(new RegisterCaseCommand
            {
                CorrelationId = message.CorrelationId,
                HealthCaseId = message.CaseId,
                PatientId = message.PatientId,
                ClinicId = message.ClinicId,
                CreatedAt = message.CreatedAt,
                DocId = message.DocId
            });

            await RequestTimeout(context, TimeSpan.FromSeconds(60), new HealthCaseStatusCheckIsDue
            {
                CorrelationId = message.CorrelationId
            });
        }

        public async Task Handle(CaseRegistrationCompleted message, IMessageHandlerContext context)
        {
            Data.CaseId = message.CaseId;
            _logger.LogInformation($"[MedicalSaga] Registration completed | CorrelationId: {message.CorrelationId}");
            _logger.LogInformation($"[MedicalSaga] Raising timeout: HealthCaseStatusCheckIsDue | CorrelationId: {message.CorrelationId}");
        
            await Task.CompletedTask;
        }

        public async Task Handle(CaseUpdateCompleted message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"[MedicalSaga] Update completed | CorrelationId: {message.CorrelationId}");
            _logger.LogInformation($"[MedicalSaga] Raising timeout: HealthCaseStatusCheckIsDue | CorrelationId: {message.CorrelationId}");
            await RequestTimeout(context, TimeSpan.FromSeconds(60), new HealthCaseStatusCheckIsDue
            {
                CorrelationId = message.CorrelationId
            });
        }

        public async Task Handle(FinalizeCaseCompleted message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"[MedicalSaga] Finalization completed. Saga marked as complete | CorrelationId: {message.CorrelationId}");
            MarkAsComplete();
            await Task.CompletedTask;
        }

        public async Task Handle(DeleteHealthCaseCompleted message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"[MedicalSaga] Delete completed. Saga marked as complete | CorrelationId: {message.CorrelationId}");
            MarkAsComplete();
            await Task.CompletedTask;
        }

        public async Task Handle(ScheduleCaseUpdateCheck message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"[MedicalSaga] Scheduling HealthCaseStatusCheckIsDue timeout | CorrelationId: {message.CorrelationId}");
            _logger.LogInformation($"[MedicalSaga] Raising timeout: HealthCaseStatusCheckIsDue | CorrelationId: {message.CorrelationId}");
            await RequestTimeout(context, TimeSpan.FromSeconds(60), new HealthCaseStatusCheckIsDue
            {
                CorrelationId = message.CorrelationId
            });
        }

        public async Task Timeout(HealthCaseStatusCheckIsDue state, IMessageHandlerContext context)
        {
            _logger.LogInformation($"[MedicalSaga] Timeout triggered: Processing case update | CorrelationId: {state.CorrelationId}");

            await context.SendLocal(new ProcessCaseUpdate
            {
                CorrelationId = Data.CorrelationId,
            });
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<MedicalInterfaceSagaData> mapper)
        {
            mapper.MapSaga(saga => saga.CorrelationId)
                .ToMessage<CaseRegistrationRequested>(message => message.CorrelationId)
                .ToMessage<CaseRegistrationCompleted>(message => message.CorrelationId)
                .ToMessage<CaseUpdateCompleted>(message => message.CorrelationId)
                .ToMessage<FinalizeCaseCompleted>(message => message.CorrelationId)
                .ToMessage<DeleteHealthCaseCompleted>(message => message.CorrelationId)
                .ToMessage<ScheduleCaseUpdateCheck>(message => message.CorrelationId);
        }

    }

    public class MedicalInterfaceSagaData : ContainSagaData
    {

        public string CaseId { get; set; }
        public string PatientId { get; set; }
        public string ClinicId { get; set; }
        public string CorrelationId { get; set; }
        public string DocId { get; set; }

        //TODO: handle stale timeout updates
    }

    public class HealthCaseStatusCheckIsDue : IProvideCorrelationId
    {
        public string CorrelationId { get; set; }
    }
}
