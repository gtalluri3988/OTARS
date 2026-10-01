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

namespace MTAoars.Validators.Operations.Fluents {
    [FluentRegisterable]
    public class CBCStartViewModelValidator : AbstractValidator<CBCStartViewModel> {

        public CBCStartViewModelValidator() {
            RuleFor(x => x.Year)
                .NotNull().WithMessage("Please select Year");

            RuleFor(x => x.Quarter)
                .NotNull().WithMessage("Please select Quarter");

        }

    }// class

}// namespace
