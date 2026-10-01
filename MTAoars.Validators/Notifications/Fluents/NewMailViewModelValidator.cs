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
using MTAoars.ViewModels.Notifications;

namespace MTAoars.Validators.Notifications.Fluents {
    
    [FluentRegisterable]
    public class NewMailViewModelValidator : AbstractValidator<NewMailViewModel> {

        
        public NewMailViewModelValidator() {
            RuleFor(x => x.CompanyIdentifiers)
                .Must((src, list) => (list != null && list.Count > 0))
                .WithMessage("Please select company");
            RuleFor(x => x.Subject).NotNull();
            RuleFor(x => x.Body).NotNull();
        }

    }// class

}// namespace
