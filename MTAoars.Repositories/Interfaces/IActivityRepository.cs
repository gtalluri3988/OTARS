using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.DomainModels;

namespace MTAoars.Repositories.Interfaces {

    public interface IActivityRepository : IRepository<Activity> {

        Activity Get(string code);

    }// interface

}// class
