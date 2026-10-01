using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Operations;
using MTAoars.DomainModels;
using System.IO;

namespace MTAoars.Builders.Interfaces {
    public interface IRegistrationBuilder {

        RegistrationStartViewModel GetStartViewModel();

        RegistrationIndexViewModel GetIndexViewModel(long companyId, long agencyTypeId);

        RegistrationIndexViewModel GetIndexViewModel();
               
        T GetNew<T>(RegistrationIndexViewModel model) where T : RegistrationViewModel;

         RegistrationInclusionViewModel GetInclusion(RegistrationIndexViewModel model);

        RegistrationConflictViewModel GetConflict(RegistrationIndexViewModel model);

        RegistrationReinstationViewModel GetReinstation(RegistrationIndexViewModel model);
        List<RegistrationResponseViewModel> GetRegistrations(Stream stream);

    }// interface
}// namespace
