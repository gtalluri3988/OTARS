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
    public class TrainingViewModelValidator : AbstractValidator<TrainingViewModel> {

        public TrainingViewModelValidator() {
            RuleFor(x => x.AgencyID)
                .NotNull().WithMessage("Agency is not assigned. Please try again");

            RuleFor(x => x.CreditHours)
                .GreaterThan(0).WithMessage("Credit hours should be required and it should be greater than 0");

            RuleFor(x => x.CourseID).NotNull()
                .When(p => p.IsStructured).WithMessage("Please select course");

            RuleFor(x => x.CourseDescription).NotNull()
                .When(p => !p.IsStructured).WithMessage("Course description is required");

            RuleFor(x => x.IntermediaryTypeID).GreaterThan(0)
                .WithMessage("Please select intermediary type");

            RuleFor(x => x.StartDate).Must((item, value) => {
                if (item.StartDate == null || item.EndDate == null) return true;
                return item.StartDate.Value <= item.EndDate.Value;
            }).WithMessage("Start date should be less than or equal to end date");

            /*RuleFor(x => x.CreditHours).Must((item, value) => {
                if (item.StartDate == null || item.EndDate == null) return true;
                var days = item.EndDate.Value.Subtract(item.StartDate.Value).Days + 1;
                return value <= days * 8d;
            }).WithMessage("The number of hours exceeded as per allowed");*/

            RuleFor(x => x.TrainingTypeID).NotNull()
                .WithMessage("Please select Training Type");
           
        }

    }// class

}// namespace
