using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Interfaces;

namespace MTAoars.ViewModels.Notifications {

    public class RenewalReminderVariableSource : INotificationVariableSource {

        public int TotalGeneratedRecords { get; set; }

        public int Year { get; set; }

        public int Quarter { get; set; }

    }// class

}// namesapce
