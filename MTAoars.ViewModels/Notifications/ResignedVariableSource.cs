using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Interfaces;

namespace MTAoars.ViewModels.Notifications {
    public class ResignedVariableSource : INotificationVariableSource {

        public string AgencyNumber { get; set; }

        public DateTime StartDate { get; set; }
    }
}
