using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Interfaces;
using MTAoars.Utilities.Constants;
using MTAoars.Utilities.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MTAoars.ViewModels.Operations {
    public class PartnerViewModel : IMemberViewModel {

        public string Name { get; set; }

        [Display(Name = "Old IC Number")]
        public string OldICNumber { get; set; }

        public LookupItem ICType { get; set; }

        [Display(Name = "New IC Number")]
        public string ICNumber { get; set; }

        public LookupItem AgencyType { get; set; }

        [Display(Name = "Family")]
        public bool IsFamily { get; set; }

        [Display(Name = "General")]
        public bool IsGeneral { get; set; }
    }
}
