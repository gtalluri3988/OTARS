using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MTAoars.Services.Interfaces;
using MTAoars.Utilities.Mvc;

namespace MTAoars.Shell.Controllers {
    [MTAoarsAuthorize]
    public class HomeController : BaseController {

        IHomeService homeService;
        public HomeController(IHomeService homeService) {
            this.homeService = homeService;
        }
       
        public ActionResult Index() {
            var model = homeService.GetModel();
            return View(model);
        }

    }// class
}// namespace
