using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Repositories.Interfaces;
using MTAoars.ViewModels.Operations;

namespace MTAoars.Services.Interfaces {
    public interface IALCService : IBaseService {
        void Save(ALCHeaderViewModel input);

    }// interface
}// 
