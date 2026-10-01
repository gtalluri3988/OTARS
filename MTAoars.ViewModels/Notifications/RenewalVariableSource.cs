using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Interfaces;

namespace MTAoars.ViewModels.Notifications {
    
    public class RenewalVariableSource : INotificationVariableSource {

        public string ValidToDate { get; set; }

        public int TotalAgents { get; set; }

    }// class

}// namesapce
