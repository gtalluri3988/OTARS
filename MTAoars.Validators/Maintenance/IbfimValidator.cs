using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Shared;
using MTAoars.Repositories.Interfaces;
using MTAoars.DomainModels;
using MTAoars.ViewModels.Interfaces;
using MTAoars.ViewModels.Operations;
using MTAoars.Utilities.Config;
using MTAoars.ViewModels.Maintenance;
using System.Text.RegularExpressions;

namespace MTAoars.Validators.Maintenance {
    public class IbfimValidator : IValidator<IbfimExcelViewModel> {
        
        public IEnumerable<ValidationMessage> Validate(IbfimExcelViewModel item) {
            if(String.IsNullOrEmpty(item.ExaminationTypeCode) ||
                !Regex.IsMatch(item.ExaminationTypeCode, "[1-3]{1,2}")) {
                item.AddError("Examination type code is invalid");
            }
            if(String.IsNullOrEmpty(item.ICNO)) {
                item.AddError("IC Number is required");
            }
            if(String.IsNullOrEmpty(item.Result) || 
                !Regex.IsMatch(item.Result, "^(Pass|Fail|Absent)$")) {
                item.AddError("Invalid result it should be either Pass or Fail or Absent");
            }
            yield break;
        }

    }// class
}// namespace
