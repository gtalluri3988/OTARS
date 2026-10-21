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
using MTAoars.DomainModels;

namespace MTAoars.Services.Accounts {

    public class UserService : IUserService {
        IUserRepository userRepository;
        IRepository<UserLogin> userLoginRepository;

        public UserService(IUserRepository userRepository, IRepository<UserLogin> userLoginRepository) {
            this.userRepository = userRepository;
            this.userLoginRepository = userLoginRepository;
        }

        public bool Authenticate(LogOnViewModel model) {
            var user = userRepository.Get(model.UserName);
            if (user == null) return false;
            return user.Password == model.Password;
        }

        public Identity Get(long userId) {
            var user = userRepository.Get(userId);
            return Mapper.Map<Identity>(user);
        }

        public Identity Get(string userName) {
            var user = userRepository.Get(userName);
            return Mapper.Map<Identity>(user);
        }

        public long SaveLoginDetail(long userId, string hostIP) {
            // Finding 12: close previous active login records when a new login succeeds.
            var now = DateTime.Now;
            foreach (var activeLogin in userLoginRepository.GetAll().Where(i => i.UserID == userId && i.LogoutTime == null)) {
                activeLogin.LogoutTime = now;
            }

            var userLogin = new UserLogin { UserID = userId, HostIP = hostIP, LoginTime = DateTime.Now };
            userLoginRepository.Save(userLogin);
            userLoginRepository.SaveChanges();
            return userLogin.ID;
        }

        public void SaveLogoutDetail(long userLoginId) {
            var userLogin = userLoginRepository.Get(userLoginId);
            if (userLogin != null) {
                userLogin.LogoutTime = DateTime.Now;
                userLoginRepository.SaveChanges();
            }
        }

    }// class

}// namespace
