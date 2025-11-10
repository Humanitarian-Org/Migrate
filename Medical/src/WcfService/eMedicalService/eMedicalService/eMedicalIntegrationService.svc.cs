using eMedicalService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using eMedicalService.Contracts.Health.Messaging.Service.V1;


namespace eMedicalService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "eMedicalIntegrationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select eMedicalIntegrationService.svc or eMedicalIntegrationService.svc.cs at the Solution Explorer and start debugging.
    public class eMedicalIntegrationService : IeMedicalIntegrationService
    {
        // Implementation placeholder - not used in corrected version
        public CacheHealthCaseDetailsResponseType CacheHealthCaseDetails(CacheHealthCaseDetailsRequestType request)
        {
            throw new NotImplementedException("Use eMedicalIntegrationServiceCorrect instead");
        }

        public DeleteCachedHealthCaseResponseType DeleteCachedHealthCase(DeleteCachedHealthCaseRequestType request)
        {
            throw new NotImplementedException("Use eMedicalIntegrationServiceCorrect instead");
        }

        public GetCachedHealthCaseResponseType GetCachedHealthCase(GetCachedHealthCaseRequestType request)
        {
            throw new NotImplementedException("Use eMedicalIntegrationServiceCorrect instead");
        }

        public GetHealthCaseStatusResponseType GetHealthCaseStatus(GetHealthCaseStatusRequestType request)
        {
            throw new NotImplementedException("Use eMedicalIntegrationServiceCorrect instead");
        }

        public NotifyMedicalExaminationStatusResponseType NotifyMedicalExaminationStatus(NotifyMedicalExaminationStatusRequestType request)
        {
            throw new NotImplementedException("Use eMedicalIntegrationServiceCorrect instead");
        }

        public RegisterHealthCaseResponseType RegisterHealthCase(RegisterHealthCaseRequestType request)
        {
            throw new NotImplementedException("Use eMedicalIntegrationServiceCorrect instead");
        }

        public RegisterMedicalExaminationsResultsResponseType RegisterMedicalExaminationsResults(RegisterMedicalExaminationsResultsRequestType request)
        {
            throw new NotImplementedException("Use eMedicalIntegrationServiceCorrect instead");
        }

        public UpdateMedicalExaminationResponseType UpdateMedicalExamination(UpdateMedicalExaminationRequestType request)
        {
            throw new NotImplementedException("Use eMedicalIntegrationServiceCorrect instead");
        }
    }
    
    // Temporary interface and types to make old service compile
    [ServiceContract]
    public interface IeMedicalIntegrationService
    {
        [OperationContract]
        CacheHealthCaseDetailsResponseType CacheHealthCaseDetails(CacheHealthCaseDetailsRequestType request);
        
        [OperationContract] 
        DeleteCachedHealthCaseResponseType DeleteCachedHealthCase(DeleteCachedHealthCaseRequestType request);
        
        [OperationContract]
        GetCachedHealthCaseResponseType GetCachedHealthCase(GetCachedHealthCaseRequestType request);
        
        [OperationContract]
        GetHealthCaseStatusResponseType GetHealthCaseStatus(GetHealthCaseStatusRequestType request);
        
        [OperationContract]
        NotifyMedicalExaminationStatusResponseType NotifyMedicalExaminationStatus(NotifyMedicalExaminationStatusRequestType request);
        
        [OperationContract]
        RegisterHealthCaseResponseType RegisterHealthCase(RegisterHealthCaseRequestType request);
        
        [OperationContract] 
        RegisterMedicalExaminationsResultsResponseType RegisterMedicalExaminationsResults(RegisterMedicalExaminationsResultsRequestType request);
        
        [OperationContract]
        UpdateMedicalExaminationResponseType UpdateMedicalExamination(UpdateMedicalExaminationRequestType request);
    }
}
