using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Operations;
using FluentValidation;
using MTAoars.Utilities.IoC;
using MTAoars.Validators.Shared.Fluent;

namespace MTAoars.Validators.Operations.Fluents {
    [FluentRegisterable()]
    public class IndividualRegistrationViewModelValidator : AbstractValidator<IndividualRegistrationViewModel> {

        public IndividualRegistrationViewModelValidator(AddressViewModelValidator addressValidator) {
            RuleFor(x => x.Address)
                .SetValidator(addressValidator);
            RuleFor(x => x.CorporateNominee.Phone)
                .NotNull();
        }

    }// class
}// namespace
