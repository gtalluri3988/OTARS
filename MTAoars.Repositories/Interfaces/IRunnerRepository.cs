using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.DomainModels;

namespace MTAoars.Repositories.Interfaces {
    public interface IRunnerRepository {

        string GetNext(string code);
    }
}
