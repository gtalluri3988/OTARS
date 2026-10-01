using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Masters;

namespace MTAoars.Services.Interfaces {
    public interface ICPDService : IBaseService {
        void Process();
        bool Check(TrainingListViewModel model);
    }// interface
}// 
