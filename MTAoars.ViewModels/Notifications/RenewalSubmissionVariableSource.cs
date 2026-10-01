using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Interfaces;

namespace MTAoars.ViewModels.Notifications {
    
    public class RenewalSubmissionVariableSource : INotificationVariableSource {

        public string CompanyName { get; set; }

        public int Year { get; set; }

        public int Quarter { get; set; }

    }// class

}// namesapce
