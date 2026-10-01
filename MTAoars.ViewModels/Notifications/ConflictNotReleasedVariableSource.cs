using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Interfaces;

namespace MTAoars.ViewModels.Notifications {
    
    public class ConflictNotReleasedVariableSource : INotificationVariableSource {

        public string AgencyNumber { get; set; }
        
        public String CompanyName { get; set; }

    }// class

}// namesapce
