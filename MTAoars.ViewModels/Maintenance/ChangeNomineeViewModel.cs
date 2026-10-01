using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Operations;
using MTAoars.ViewModels.Interfaces;
using MTAoars.Utilities.Constants;
using MTAoars.Utilities.Mvc;

namespace MTAoars.ViewModels.Maintenance {
    public class ChangeNomineeViewModel: IExistableTbeDetails {

        public long PrincipalID { get; set; }

        public RegistrationViewModel RegistrationModel { get; set; }

        public string ICNumber { 
            get { 
                var code = RegistrationModel.CorporateNominee.ICType.Code;
                if(code == LookupConstants.ICTypes.NewIc)return RegistrationModel.CorporateNominee.NewICNumber;
                return RegistrationModel.CorporateNominee.PassportNumber;
            }
        }

        public bool IsFamily {
            get { return RegistrationModel.Agency.IsFamily; }
        }

         public bool IsGeneral {
            get { return RegistrationModel.Agency.IsGeneral; }
        }

        public LookupItem TbeCategory {
            get {
                return RegistrationModel.CorporateNominee.TbeCategory;
            }
        }
        public bool IsOld { get; set; }

    }// class
}// namespace
