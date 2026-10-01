using System.Collections.Generic;
using Microsoft.Practices.Unity;
using MTAoars.Utilities.Attributes;
using MTAoars.Utilities.Mvc;

namespace MTAoars.ViewModels.Operations {
    public class TerminationSearchViewModel {

        [Dependency]
        public AgencySearchRequestViewModel AgencySearch { get; set; }
        
        [Binder(typeof(JsonModelBinder))]
        [Dependency]
        public List<TerminationSearchResponseViewModel> TerminationAgents { get; set; }

        public IEnumerable<LookupItem> TerminationActions { get; set; }
    }
}
