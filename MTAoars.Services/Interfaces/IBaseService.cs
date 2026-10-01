using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Services.Shared;

namespace MTAoars.Services.Interfaces {
    public interface IBaseService {

        ServiceContext CurrentContext { get; }
    }
}
