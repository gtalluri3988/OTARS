    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Interfaces;

namespace MTAoars.ViewModels.Notifications {
    
    public class ChangeNomineeVariableSource : INotificationVariableSource {

        public string NewICNumber { get; set; }

        public string Name { get; set; }
    }// class

}// namesapce
