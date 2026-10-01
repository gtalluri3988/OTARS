using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Repositories.Interfaces;
using MTAoars.Repositories.Shared;
using MTAoars.DomainModels;

namespace MTAoars.Repositories.Accounts {
    public class UserRepository : GenericRepository<User>, IUserRepository {

        public UserRepository(EntityContext context)
            : base(context) {
        }

        public User Get(string userName) {
            return Context.Users.Where(p => p.UserName == userName).FirstOrDefault();
        }

        public User Get(long userID)
        {
            return Context.Users.SingleOrDefault(p => p.ID == userID);
        }
    }// class
}// namespace
