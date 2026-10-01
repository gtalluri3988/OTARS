using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Operations;
using Microsoft.Practices.Unity;
using MTAoars.Utilities.Attributes;
using MTAoars.Utilities.Mvc;

namespace MTAoars.ViewModels.Maintenance
{
    public  class SearchViewModel
    {
        [Dependency]
        public AgencySearchRequestViewModel AgencySearch { get; set; }

        [Binder(typeof(JsonModelBinder))]
        public IEnumerable<TerminationSearchResponseViewModel> TerminationAgents { get; set; }



    }
}
