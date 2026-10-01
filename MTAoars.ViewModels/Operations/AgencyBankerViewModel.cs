using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Utilities.Mvc;
using MTAoars.ViewModels.Shared;
using Microsoft.Practices.Unity;
using System.ComponentModel.DataAnnotations;

namespace MTAoars.ViewModels.Operations {
    public class AgencyBankerViewModel {
        
        [Display(Name = "Bank")]
        public LookupItem Bank { get; set; }

        [Display(Name = "Account Type")]
        public LookupItem AccountType { get; set; }

        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }

        [Dependency]
        public AddressViewModel Address { get; set; }

    }
}
