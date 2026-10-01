using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Operations;
using MTAoars.Utilities.Attributes;
using MTAoars.Utilities.Mvc;
using Microsoft.Practices.Unity;

namespace MTAoars.ViewModels.Interfaces {
    public interface IExistableBoardMembers {

      List<DirectorViewModel> Directors { get; set; }
      List<ShareholderViewModel> Shareholders { get; set; }
      List<AdditionalCorporateNomineeViewModel> AdditionalCorporateNominees { get; set; }
      IEnumerable<LookupItem> ICTypes { get; set; }

    }
}
