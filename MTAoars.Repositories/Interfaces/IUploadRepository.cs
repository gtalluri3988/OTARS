using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.DomainModels;


namespace MTAoars.Repositories.Interfaces {
    public interface IUploadRepository : IRepository<UploadHistory> {
        string GetAgencyNumber(long agencyId);
    }
}
