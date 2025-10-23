$env:AzureServiceBus_ConnectionString = '<<ASB_CONNECTION_STRING>>'

asb-transport queue create error
asb-transport queue create audit 

# nsb endpoints
asb-transport endpoint create ASBMedicalMessageProcessor
asb-transport endpoint create ASBMedicalMessageWorker
asb-transport endpoint create ASBMedicalResponseWorker

# Message Worker Subscriptions
asb-transport endpoint subscribe ASBMedicalMessageWorker Medical.Domain.Contracts.Events.CaseRegistrationRequested
asb-transport endpoint subscribe ASBMedicalMessageWorker Medical.Domain.Contracts.Events.CaseRegistrationCompleted
asb-transport endpoint subscribe ASBMedicalMessageWorker Medical.Domain.Contracts.Events.CaseUpdateRequested
asb-transport endpoint subscribe ASBMedicalMessageWorker Medical.Domain.Contracts.Events.CaseUpdateCompleted
asb-transport endpoint subscribe ASBMedicalMessageWorker Medical.Domain.Contracts.Events.FinalizeCaseRequested
asb-transport endpoint subscribe ASBMedicalMessageWorker Medical.Domain.Contracts.Events.FinalizeCaseCompleted
asb-transport endpoint subscribe ASBMedicalMessageWorker Medical.Domain.Contracts.Events.DeleteHealthCaseRequested
asb-transport endpoint subscribe ASBMedicalMessageWorker Medical.Domain.Contracts.Events.DeleteHealthCaseCompleted

asb-transport endpoint subscribe ASBMedicalMessageWorker Medical.Domain.Contracts.Events.eMedicalMsgRecieved

# Response Worker Subscriptions
asb-transport endpoint subscribe ASBMedicalResponseWorker Medical.Domain.Contracts.Events.CaseRegistrationCompleted
asb-transport endpoint subscribe ASBMedicalResponseWorker Medical.Domain.Contracts.Events.CaseUpdateCompleted
asb-transport endpoint subscribe ASBMedicalResponseWorker Medical.Domain.Contracts.Events.FinalizeCaseCompleted
asb-transport endpoint subscribe ASBMedicalResponseWorker Medical.Domain.Contracts.Events.DeleteHealthCaseCompleted
