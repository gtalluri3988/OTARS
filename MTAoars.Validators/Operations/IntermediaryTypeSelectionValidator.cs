using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Shared;
using MTAoars.Repositories.Interfaces;
using MTAoars.DomainModels;
using MTAoars.ViewModels.Interfaces;
using MTAoars.ViewModels.Operations;
using MTAoars.Utilities.Interfaces;
using MTAoars.Utilities.Constants;
using MTAoars.Utilities.Mvc;

namespace MTAoars.Validators.Operations {
    public class IntermediaryTypeSelectionValidator : IValidator<RegistrationIndexViewModel> {

        IScopeDataProvider dataProvider;

        public IntermediaryTypeSelectionValidator(IScopeDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public IEnumerable<ValidationMessage> Validate(RegistrationIndexViewModel item)
        {
            var currentIdentity = dataProvider.Get<Identity>(GlobalConstants.CurrentIdentity);

            if (!currentIdentity.IsISMOrMTA)
            {
                if (!currentIdentity.IsFamily && item.IsFamily)
                    yield return new ValidationMessage("", "Your company not allow to register Family agent.");
                if (!currentIdentity.IsGeneral && item.IsGeneral)
                    yield return new ValidationMessage("", "Your company not allow to register General agent.");
            }

            if (!item.IsFamily && !item.IsGeneral) {
                yield return new ValidationMessage("", "Please select intermediary type");
            }
        }

    }// class
}// namespace
