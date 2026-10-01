using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Interfaces;

namespace MTAoars.ViewModels.Notifications {
    
    public class InvoiceVariableSource : INotificationVariableSource {

        public int Month { get; set; }

        public int Year { get; set; }

        public decimal Amount { get; set; }
        
    }// class

}// namesapce
