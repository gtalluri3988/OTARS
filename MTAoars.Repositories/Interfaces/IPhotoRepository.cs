using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.DomainModels;


namespace MTAoars.Repositories.Interfaces {
    public interface IPhotoRepository : IRepository<PhotoHistory> {

        List<PhotoHistory> Enquiry(string agencyNumber);        

    }
}
