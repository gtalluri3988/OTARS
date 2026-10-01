using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Utilities.Constants;
using MTAoars.Utilities.Mvc;

namespace MTAoars.ViewModels.Notifications {
    public class NewMailViewModel {

        public string Subject { get; set; }

        public string Body { get; set; }

        public List<long> CompanyIdentifiers { get; set; }

        public IEnumerable<LookupItem> Companies { get; set; }

    }// class
}// namespace
