using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Operations;
using FluentValidation;
using MTAoars.Utilities.IoC;
using Microsoft.Practices.Unity;
using MTAoars.Repositories.Interfaces;
using MTAoars.Utilities.Constants;
using MTAoars.DomainModels;    
using MTAoars.Validators.Shared.Fluent;


namespace MTAoars.Validators.Operations.Fluents {
    [FluentRegisterable]
    public class SoleProprietorshipRegistrationViewModelValidator : CorporateRegistrationViewModelValidator<SoleProprietorshipRegistrationViewModel> {

        public SoleProprietorshipRegistrationViewModelValidator(AgencyViewModelValidator agencyValidator, AddressViewModelValidator addressValidator):base(agencyValidator, addressValidator) {
           
        }

    }// class

}// namespace
