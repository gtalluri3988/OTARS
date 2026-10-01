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
using MTAoars.ViewModels.Masters;
using MTAoars.Utilities.Extensions;
using MTAoars.ViewModels.Maintenance;

namespace MTAoars.Validators.Operations.Fluents {
    [FluentRegisterable]
    public class ReferredMemberViewModelValidator : AbstractValidator<ReferredDetailViewModel> {

        public ReferredMemberViewModelValidator() {
            RuleFor(x => x.Name)
                .NotNull()
                .Length(1, 50);
            RuleFor(x => x.Reason)
                .Must(x => x != null)
                .WithMessage("Please select Reason");
            RuleFor(x => x.Category)
                .Must(x=> x!= null)
                .WithMessage("Please select Category");
            RuleFor(x => x.ICNumber)
              .Must(ValidateNewIC)
              .WithMessage("New IC number should be 12 digits and begin with date of birth (yyMMdd) format");
            
        }

        bool ValidateNewIC(string icNumber) {
            return icNumber.IsNewIC();
        }

    }// class

}// namespace
