using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Interfaces;
using MTAoars.Utilities.Attributes;

namespace MTAoars.ViewModels.Notifications {
    
    public class BatchTerminationVariableSource : INotificationVariableSource, IExistableTerminationList {

        public BatchTerminationVariableSource() {
            TerminationList = new List<TerminatedVariableSource>();
        }

        [ValueProvider(typeof(TerminationListValueProvider))]
        public List<TerminatedVariableSource> TerminationList { get; private set; }
        
    }// class

}// namesapce
