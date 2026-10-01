    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Interfaces;

namespace MTAoars.ViewModels.Notifications {
    
    public class ChangeCompanyVariableSource : INotificationVariableSource {

        public string AgencyName { get; set; }

        public string OldCompanyName { get; set; }

        public string NewCompanyName { get; set; }

    }// class

}// namesapce
