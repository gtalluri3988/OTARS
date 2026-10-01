using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Services.Interfaces;
using MTAoars.ViewModels.Accounts;
using MTAoars.Repositories.Interfaces;
using MTAoars.ViewModels.Shared;
using AutoMapper;
using MTAoars.Utilities.Mvc;

namespace MTAoars.Services.Accounts {

    public class MenuService : IMenuService {
        IMenuRepository menuRepository;

        public MenuService(IMenuRepository menuRepository) {
            this.menuRepository = menuRepository;
        }

        public List<MenuItem> GetMenus() {
            return menuRepository.GetMenus();
        }

        public List<MenuItem> GetMenus(long roleId) {
            return menuRepository.GetMenus(roleId);
        }

        public List<long> GetRoleMenus(long roleId) {
            return menuRepository.GetRoleMenus(roleId);
        }

        public void Save(long roleId, IEnumerable<long> menus) {
            menuRepository.Save(roleId, menus);
        }

    }// class

}// namespace
