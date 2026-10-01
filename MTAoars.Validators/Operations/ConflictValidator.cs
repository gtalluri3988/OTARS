using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Operations;
using MTAoars.Repositories.Operations;
using MTAoars.ViewModels.Shared;
using MTAoars.Utilities.Interfaces;
using MTAoars.Utilities.Constants;
using MTAoars.Repositories.Interfaces;
using MTAoars.DomainModels;
using MTAoars.Utilities.Mvc;

namespace MTAoars.Validators.Operations {
    public class ConflictValidator : IValidator<RegistrationConflictViewModel> {


        public IEnumerable<ValidationMessage> Validate(RegistrationConflictViewModel item) {
            if (item.SourceCompanyID <= 0) {
                yield return new ValidationMessage("", "Please select Source Company");
            }
           if(item.ConflictAttachments.Count < 2){
               yield return new ValidationMessage("", "Please attach Agent Movement Form and Termination Letter");
           }
        }

    }// class
}// namesapce
