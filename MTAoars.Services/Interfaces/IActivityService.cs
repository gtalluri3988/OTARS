using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Maintenance;

namespace MTAoars.Services.Interfaces {
    public interface IActivityService : IBaseService {

        void Save(AdminActivityViewModel model);

    }// interface
}// 
