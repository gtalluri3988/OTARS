using MTAoars.ViewModels.Operations;
using MTAoars.Utilities.Constants;
using MTAoars.ViewModels.Maintenance;
using MTAoars.ViewModels.Shared;

namespace MTAoars.Services.Interfaces {

    public interface IRegistrationService : IBaseService {
        
        RegistrationCheckOptions Check(RegistrationIndexViewModel model);
        bool Check(RegistrationViewModel model);
        long Add(RegistrationViewModel model);
        void Add(RegistrationUploadViewModel model);
        long Add(RegistrationConflictViewModel model);
        void Include(RegistrationInclusionViewModel model);
        void Reinstate(RegistrationReinstationViewModel model);
        void UpdateAddress(RegistrationViewModel model,long principalId);
        void UpdateGuarantor(RegistrationViewModel model, long principalId);
        void ChangeNominee(ChangeNomineeViewModel model);
        void UpdatePartners(RegistrationViewModel model, long principalId);
        void UpdateBoardMembers(RegistrationViewModel model, long principalId);
        void UpdateACN(RegistrationViewModel model, long principalId);
        void UpdateCompanyName(ChangeCompanyViewModel model);
        void UpdateAgency(RegistrationViewModel model, long principalId);
        void ChangeAgencyType(long principalId, string newTypeCode);
        RegistrationViewModel Get(long id);
        RegistrationViewModel GetByPrincipal(long id);
        void UpdatePhoto(string path, long principalId);

    }// interface
}// class
