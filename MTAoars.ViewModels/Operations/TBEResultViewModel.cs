using Microsoft.Practices.Unity;
using MTAoars.Utilities.Attributes;
using MTAoars.Utilities.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTAoars.ViewModels.Operations
{
    public class TBEResultViewModel
    {
        [Binder(typeof(JsonModelBinder))]
        [Dependency]
        public TBEEnquirySearchViewModel TBEResult { get; set; }

    }
}
