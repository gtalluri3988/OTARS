using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.DomainModels;
using MTAoars.ViewModels.Operations;

namespace MTAoars.Services.Operations {

    class RegistrationContext {

        public RegistrationViewModel Model { get; set; }

        public Agency Agency { get; set; }
    }

}
