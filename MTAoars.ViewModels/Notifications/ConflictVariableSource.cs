using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Interfaces;

namespace MTAoars.ViewModels.Notifications {
    
    public class ConflictVariableSource : INotificationVariableSource {

        public string AgencyNumber { get; set; }

        public string Date { get; set; }

        public string ICNumber { get; set; }

        public string SourceCompany { get; set; }

        public string DestinationCompany { get; set; }

    }// class

}// namesapce
