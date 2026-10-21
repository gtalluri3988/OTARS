using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MTAoars.ViewModels.Accounts;
using MTAoars.Utilities.Mvc;
using MTAoars.Services.Interfaces;
using MTAoars.Utilities.Interfaces;
using MTAoars.Utilities.Constants;
using MTAoars.ViewModels.Shared;
using MTAoars.Utilities.Config;
using System.Security.Claims;
using MTAoars.Utilities.Extensions;
using System.Web.Security;

namespace MTAoars.Web.Controllers
{
    public class AccountController : BaseController
    {

        IUserService userService;
        IScopeDataProvider dataProvider;
        IMenuService menuService;
        ConfigManager config;

        public AccountController(IUserService userService, IScopeDataProvider dataProvider, IMenuService menuService, ConfigManager config)
        {
            this.userService = userService;
            this.dataProvider = dataProvider;
            this.menuService = menuService;
            this.config = config;
        }
        // [Authorize]
        public ActionResult LogOn()
        {

            var identity = dataProvider.Get<Identity>(GlobalConstants.CurrentIdentity);
            //if (identity == null) { return Redirect(config.SSOUrl); }
            //else { return RedirectToAction("Index", "Home"); }

            if (this.User.Identity.IsAuthenticated && identity == null)
            {
                var sub = (User.Identity as ClaimsIdentity).Claims.FirstOrDefault(i => i.Type == "sub").Value;
                identity = userService.Get(sub);
                // Finding 12: record this login and invalidate previous active login records.
                identity.UserLoginID = userService.SaveLoginDetail(identity.UserID, Request.UserHostAddress);
                dataProvider.Register(GlobalConstants.CurrentIdentity, identity);
            }

            if (identity != null)
                return RedirectToAction("Index", "Home");

            return View(new LogOnViewModel());
        }

        [HttpPost]
        public JsonResult LogOnSubmit(LogOnViewModel model)
        {
            var output = GetResponse();
            if (output.Result == false) return Json(output);

            if (model.CaptchaKey == null || model.CaptchaKey.Equals(Session[GlobalConstants.CaptchaKey]) == false)
            {
                output.AddError("Security key does not match");
                output.Result = false;
                return Json(output);
            }

            if (!userService.Authenticate(model))
            {
                output.AddError("User name or password does not match");
                output.Result = false;
                return Json(output);
            }
            var identity = userService.Get(model.UserName);
            // Finding 12: record this login and invalidate previous active login records.
            identity.UserLoginID = userService.SaveLoginDetail(identity.UserID, Request.UserHostAddress);
            dataProvider.Register(GlobalConstants.CurrentIdentity, identity);
            output.RedirectUrl = Url.Action("Index", "Home");
            return Json(output);
        }

        public ActionResult LogOut()
        {
            var identity = dataProvider.Get<Identity>(GlobalConstants.CurrentIdentity);
            dataProvider.Remove(GlobalConstants.CurrentIdentity);

            if (identity != null && identity.UserLoginID > 0)
                userService.SaveLogoutDetail(identity.UserLoginID);

            // Finding 5: clear authentication/session state on the server during logout.
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                var sessionCookie = new HttpCookie("ASP.NET_SessionId", string.Empty);
                sessionCookie.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(sessionCookie);
            }

            // Finding 6: prevent Back-button access to cached authenticated pages after logout.
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetNoStore();
            Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            Response.Headers.Set("Cache-Control", "no-store, no-cache, must-revalidate, max-age=0");
            Response.Headers.Set("Pragma", "no-cache");
            Response.Headers.Set("Expires", "Thu, 01 Jan 1970 00:00:00 GMT");
            //return View("LogOn", new LogOnViewModel());
            //return Redirect("/home.aspx");
            return Redirect(config.SSOUrl);
        }

        public ActionResult Unauthorized()
        {
            return View();
        }

        public ActionResult CaptchaImage()
        {
            var imageBuilder = new XCaptcha.ImageBuilder();
            var random = new XCaptcha.RandomTextGenerator();
            var result = imageBuilder.Create(random.Create(5, true));
            Session.Add(GlobalConstants.CaptchaKey, result.Solution);
            return new FileContentResult(result.Image, result.ContentType);

        }


    }// class
}// namespace
