using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Accounts;
using MTAoars.ViewModels.Shared;
using MTAoars.Utilities.Mvc;

namespace MTAoars.Services.Interfaces {
    public interface IUserService {

        bool Authenticate(LogOnViewModel model);

        Identity Get(long userId);

        Identity Get(string userName);

        long SaveLoginDetail(long userId, string hostIP);

        void SaveLogoutDetail(long userLoginId);
    }
}
