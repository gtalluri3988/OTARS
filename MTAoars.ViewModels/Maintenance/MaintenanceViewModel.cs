using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Operations;
using MTAoars.ViewModels.Shared;

namespace MTAoars.ViewModels.Maintenance
{
   public  class MaintenanceViewModel
    {
       
       public string Type { get; set; }       
       public string ActionName { get; set; }
       public string ViewName { get; set; }
       public RegistrationViewModel Registration { get; set; }

    }


   

  
}
