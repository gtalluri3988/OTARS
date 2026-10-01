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
    public class PartnershipRegistrationViewModelValidator : CorporateRegistrationViewModelValidator<PartnershipRegistrationViewModel> {

        public PartnershipRegistrationViewModelValidator(AgencyViewModelValidator agencyValidator,
            AddressViewModelValidator addressValidator) : base(agencyValidator, addressValidator){
            RuleFor(x =>  x.Partners)
                .Must(list => (list != null && list.Count > 0))
                .WithMessage("Atleast one partner is required");
        }

    }// class
}// namespace
