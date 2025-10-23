$env:AzureServiceBus_ConnectionString = '<<ASB_CONNECTION_STRING>>'


asb-transport queue create error
asb-transport queue create audit 

# nsb endpoints
asb-transport endpoint create ASBBeneficiaryMessageProcessor
asb-transport endpoint create ASBBeneficiaryMessageWorker
asb-transport endpoint create ASBBeneficiaryResponseWorker

# Message Worker Subscriptions
asb-transport endpoint subscribe ASBBeneficiaryMessageWorker Platform.Domain.Contracts.Commands.CreateBeneficiaryCommand
#asb-transport endpoint subscribe ASBBeneficiaryMessageWorker Beneficiary.Domain.Contracts.Events.BeneficiaryRegistrationRequested
#asb-transport endpoint subscribe ASBBeneficiaryMessageWorker Beneficiary.Domain.Contracts.Events.BeneficiaryRegistrationCompleted

# Response Worker Subscriptions
#asb-transport endpoint subscribe ASBBeneficiaryResponseWorker Beneficiary.Domain.Contracts.Events.BeneficiaryRegistrationCompleted