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
    public class UserViewModelValidator : AbstractValidator<UserMasterViewModel> {

        public UserViewModelValidator() {
            RuleFor(x => x.Name)
                .NotNull()
                .Length(1, 50);
            RuleFor(x => x.UserName)
                .NotNull()
                .Length(1, 100);
          
            
        }

    }// class

}// namespace
