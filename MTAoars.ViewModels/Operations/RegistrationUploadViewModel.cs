using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTAoars.ViewModels.Operations
{
    public class RegistrationUploadViewModel
    {
        public List<RegistrationResponseViewModel> Registrations { get; set; }

        public bool IsOld { get; set; }
    }
}
