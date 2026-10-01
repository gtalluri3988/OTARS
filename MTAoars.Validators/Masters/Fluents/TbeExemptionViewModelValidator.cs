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

namespace MTAoars.Validators.Operations.Fluents
{
    [FluentRegisterable]
    public class TbeExemptionViewModelValidator : AbstractValidator<TbeExemptionViewModel>
    {

        public TbeExemptionViewModelValidator()
        {
            RuleFor(x => x.ICNumber)
              .NotNull()
              .Must(ValidateNewIC)
              .WithMessage("New IC number should be 12 digits and begin with date of birth (yyMMdd) format");

            RuleFor(x => x.Name)
                .NotNull();
            RuleFor(x => x.DateDocumentReceived)
                .NotNull();

        }

        bool ValidateNewIC(string icNumber)
        {
            return icNumber.IsNewIC();
        }

    }// class

}// namespace
