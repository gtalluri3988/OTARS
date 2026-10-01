    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Interfaces;

namespace MTAoars.ViewModels.Notifications {
    
    public class UpdateGuarantorVariableSource : INotificationVariableSource {

        public string AgencyName { get; set; }

        public string GuarantorTypeDescription { get; set; }

    }// class

}// namesapce
