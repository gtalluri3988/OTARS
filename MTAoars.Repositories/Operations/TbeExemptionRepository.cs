using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Repositories.Interfaces;
using MTAoars.Repositories.Shared;
using MTAoars.DomainModels;
using MTAoars.Utilities.Config;

namespace MTAoars.Repositories.Operations {

    public class TbeExemptionRepository : GenericRepository<TbeExemption>, ITbeExemptionRepository {

        public TbeExemptionRepository(EntityContext context)
            : base(context) {
              
        }

        public IEnumerable<TbeExemption> Search(string icNumber) {
            return Context.TbeExemptions.Where(p => p.ICNumber == icNumber).AsEnumerable();
        }


    }// class

}// namespace
