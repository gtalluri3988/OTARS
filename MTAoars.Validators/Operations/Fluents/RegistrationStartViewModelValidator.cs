using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using MTAoars.ViewModels.Operations;
using System.Globalization;
using MTAoars.Repositories.Interfaces;
using MTAoars.DomainModels;
using MTAoars.Utilities.Constants;

namespace MTAoars.Validators.Operations.Fluents {
    [FluentRegisterable]
    public class RegistrationStartViewModelValidator : AbstractValidator<RegistrationStartViewModel> {

        public RegistrationStartViewModelValidator(ILookupRepository lookupRepository) {
            RuleFor(x => x.Company).NotNull().WithMessage("Company is required");
            RuleFor(x => x.AgencyType).NotNull().WithMessage("Please select registration type");
        }

        

    }// class

}// namespace
