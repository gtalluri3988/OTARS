using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.DomainModels;


namespace MTAoars.Repositories.Interfaces
{
    public interface IReferredRepository : IRepository<ReferredHeader>
    {

        ReferredDetail GetDetail(string icNumber);

        ReferredDetail GetDetailByCompany(string icNumber, long referredHeaderID, long reasonId);
    }
}
