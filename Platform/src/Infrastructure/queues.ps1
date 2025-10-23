$env:AzureServiceBus_ConnectionString = '<<ASB_CONNECTION_STRING>>'


asb-transport queue create error
asb-transport queue create audit 
asb-transport queue create particular.monitoring

# nsb endpoints
asb-transport endpoint create ASBPlatformMessageProcessor
asb-transport endpoint create ASBPlatformMessageWorker
asb-transport endpoint create ASBPlatformResponseWorker

# Message Worker Subscriptions
asb-transport endpoint subscribe ASBPlatformMessageWorker Platform.Domain.Contracts.Events.BulkBeneficiaryParsedAndSent
asb-transport endpoint subscribe ASBPlatformMessageWorker Platform.Domain.Contracts.Events.BulkBeneficiarySagaStarted
asb-transport endpoint subscribe ASBPlatformMessageWorker Platform.Domain.Contracts.Events.BulkBeneficiaryUploadStarted
asb-transport endpoint subscribe ASBPlatformMessageWorker Platform.Domain.Contracts.Events.BulkBeneficiaryUploadProgress
asb-transport endpoint subscribe ASBPlatformMessageWorker Platform.Domain.Contracts.Events.BulkBeneficiaryUploadCompleted
asb-transport endpoint subscribe ASBPlatformMessageWorker Platform.Domain.Contracts.Events.BulkBeneficiaryUploadTimedOut

asb-transport endpoint subscribe ASBPlatformMessageWorker Platform.Domain.Contracts.Events.SystemConfigurationCompleted
asb-transport endpoint subscribe ASBPlatformMessageWorker Platform.Domain.Contracts.Events.SystemConfigurationCompleted

# Beneficiary Event Subscriptions (events published by Beneficiary domain)
asb-transport endpoint subscribe ASBPlatformMessageWorker Beneficiary.Domain.Contracts.Events.BeneficiaryCreationSuccess
asb-transport endpoint subscribe ASBPlatformMessageWorker Beneficiary.Domain.Contracts.Events.BeneficiaryCreationFailed


# Response Worker Subscriptions
asb-transport endpoint subscribe ASBPlatformResponseWorker Platform.Domain.Contracts.Events.SystemConfigurationCompleted