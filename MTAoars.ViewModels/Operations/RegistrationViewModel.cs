using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Shared;
using MTAoars.Utilities.Constants;
using MTAoars.Utilities.Mvc;
using Microsoft.Practices.Unity;
using MTAoars.ViewModels.Interfaces;
using MTAoars.Utilities.Attributes;


namespace MTAoars.ViewModels.Operations {
    public abstract class RegistrationViewModel : IExistableGuarantor, IExistableCompanyGuarantor {

        public RegistrationViewModel() {
            AdditionalCorporateNominee = new AdditionalCorporateNomineeViewModel();
        }

        public LookupItem AgencyType { get; set; }

        public long CompanyID { get; set; }

        public AgencyViewModel Agency { get; set; }

        [Dependency]
        public AddressViewModel Address { get; set; }

        [Dependency]
        public CorporateNomineeViewModel CorporateNominee { get; set; }

        [Dependency]
        public AdditionalCorporateNomineeViewModel AdditionalCorporateNominee { get; set; }

        [Dependency]
        public GuarantorViewModel Guarantor { get; set; }

        public DateTime? DateAppointed { get; set; }

        public Actions CurrentAction { get; set; }

        
        public IEnumerable<LookupItem> ICTypes { get; set; }
        
        [IgnoreValidate]
        public string PhotoPath { get; set; }
        
        public string AgencyNumber { get; set; } //Use for administrative section
        public DateTime? DateTerminated { get; set; } //Use for administrative section
        public string AgencyPrincipalKey { get; set; } //Use for administrative section (Agency Principal ID)

    }// class
}// namespace
