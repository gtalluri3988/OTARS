using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Accounts;
using MTAoars.ViewModels.Shared;
using MTAoars.Utilities.Mvc;

namespace MTAoars.Services.Interfaces {
    public interface IMenuService {

        List<MenuItem> GetMenus();

        List<MenuItem> GetMenus(long roleId);

        void Save(long roleId, IEnumerable<long> menus);

        List<long> GetRoleMenus(long roleId);
    }
}
