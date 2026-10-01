using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.DomainModels;

namespace MTAoars.Repositories.Interfaces {
    
    public interface IMiiResultRepository : IRepository<MiiResult> {

        IEnumerable<MiiResult> Search(string icNumber);

        MiiResult Search(int id);

        void Update(MiiResult source,out string message);
    }// interface

}// namespace
