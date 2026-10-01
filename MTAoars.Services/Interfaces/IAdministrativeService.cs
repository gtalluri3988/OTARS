using MTAoars.ViewModels.Operations;
using MTAoars.Utilities.Constants;
using MTAoars.ViewModels.Maintenance;
using MTAoars.ViewModels.Shared;
using MTAoars.ViewModels.Administrative;

namespace MTAoars.Services.Interfaces
{
    public interface IAdministrativeService : IBaseService
    {
        void UpdateAgency(AdministrativeAgentViewModel model, long principalId, bool isTerminated);
        AdministrativeAgentViewModel GetByPrincipal(long id);
        AdministrativeAgentViewModel GetByPrincipalHistory(long id);
        void InsertTBEResultToAuditTrail(TBEEnquirySearchViewModel model, string TableName);
        void InsertReferredToAuditTrail(ReferredSearchViewModel model);
        void InsertRenewalToAuditTrail(RenewalDetailsViewModel model);
    }// interface
}
