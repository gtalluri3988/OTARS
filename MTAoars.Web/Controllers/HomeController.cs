using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MTAoars.Services.Interfaces;
using MTAoars.Utilities.Mvc;
using MTAoars.Utilities.Interfaces;
using MTAoars.Utilities.IoC;
using MTAoars.Utilities.Constants;
using Microsoft.Practices.Unity;
using MTAoars.Utilities;

namespace MTAoars.Web.Controllers
{

    public class HomeController : BaseController
    {

        IHomeService homeService;
        IUserService userService;
        public HomeController(IHomeService homeService, IUserService userService)
        {
            this.homeService = homeService;
            this.userService = userService;
        }

        public ActionResult Authorize(string userName)
        {
            var dataProvider = ObjectContainer.Container.Resolve<IScopeDataProvider>();
            var identity = userService.Get(userName);
            identity.UserLoginID = userService.SaveLoginDetail(identity.UserID, Request.UserHostAddress);
            dataProvider.Register(GlobalConstants.CurrentIdentity, identity);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Index()
        {
            if (!base.CurrentUser.IsLogin)
                return RedirectToAction("LogOn", "Account");

            var model = homeService.GetModel();
            return View(model);
        }

        public ActionResult Print()
        {
            return View();
        }

        public ActionResult Error(string responseCode)
        {
            logger.Info("Error Page...");
            TempData["ResponseCode"] = "";
            if (!string.IsNullOrEmpty(responseCode))
                TempData["ResponseCode"] = responseCode;
            if (base.CurrentUser.IsLogin)
                return View("Error", "~/Views/Shared/_Layout.cshtml", null);
            return View();
        }
    }// class
}
