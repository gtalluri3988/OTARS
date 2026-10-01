using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Operations;
using MTAoars.Utilities.Mvc;

namespace MTAoars.ViewModels.Interfaces {
    public interface IExistableAgency {

        AgencyViewModel Agency { get; set; }

        LookupItem AgencyType { get; }

    }
}
