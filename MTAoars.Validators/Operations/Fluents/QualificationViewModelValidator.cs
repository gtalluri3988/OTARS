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

namespace MTAoars.Validators.Operations.Fluents {
    
    [FluentRegisterable]
    public class QualificationViewModelValidator : AbstractValidator<QualificationViewModel> {

        public QualificationViewModelValidator(ILookupRepository lookupRepository, SpouseViewModelValidator spouseValidator) {
            RuleFor(x => x.EducationalQualification)
                .NotNull();
                
            RuleFor(x => x.SchoolName)
                //.NotNull()
                .Length(0, 100);
            RuleFor(x => x.Year)
                .NotNull();
                
                    
        }

    }// class

}// namespace
