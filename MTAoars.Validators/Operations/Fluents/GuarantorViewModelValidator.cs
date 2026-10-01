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
    public class GuarantorViewModelValidator : AbstractValidator<GuarantorViewModel> {

        ILookupRepository lookupRepository;
        public GuarantorViewModelValidator(ILookupRepository lookupRepository) {
            this.lookupRepository = lookupRepository;
            RuleFor(x => x.GuarantorType).NotNull();
            RuleFor(x => x.Details).NotNull().When(CheckCondition);
            RuleFor(x => x.Amount).NotNull().When(CheckCondition);
            RuleFor(x => x.FromDate).NotNull().When(CheckCondition);
            RuleFor(x => x.ToDate).NotNull().When(CheckCondition);
        }

        bool CheckCondition(GuarantorViewModel model) {
            if (model.GuarantorType == null) return false;
            return model.GuarantorType.Code != LookupConstants.GuarantorTypes.NoGuarantee;
        }

    }// class

}// namespace
