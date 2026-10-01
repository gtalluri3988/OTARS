using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MTAoars.Utilities.IoC;
using MTAoars.ViewModels.Operations;
using MTAoars.Builders.Interfaces;
using MTAoars.Utilities.Mvc;
using MTAoars.Services.Interfaces;
using MTAoars.Utilities.Constants;
using MTAoars.Utilities.Interfaces;
using MTAoars.ViewModels.Masters;

namespace MTAoars.Web.Controllers {

    [MTAoarsAuthorize]
    public class ComplaintController : BaseController {
        
        IAgencyBuilder agencyBuilder;
        IScopeDataProvider dataProvider;

        public ComplaintController(IAgencyBuilder agencyBuilder, IScopeDataProvider dataProvider) {
            this.agencyBuilder = agencyBuilder;
            this.dataProvider = dataProvider;
        }

        public ActionResult List() {
            return View(new ComplaintViewModel());
        }

        public ActionResult Create() {
            return PartialView();
        }

        public ActionResult Edit() {
            return PartialView();
        }

        public ActionResult Display() {
            return PartialView();
        }

        public ActionResult Search(string agencyNumber) {
            var identity = dataProvider.Get<Identity>(GlobalConstants.CurrentIdentity);
            var item = agencyBuilder.Search<AgencySearchResponseViewModel>(agencyNumber, identity.CompanyID);
            var output = GetResponse(agencyBuilder.CurrentContext);
            output.Data = item;
            return Json(output);
        }

        public ActionResult Save(ComplaintViewModel model) {
            return View();
        }

        public ActionResult ValidateComplaint(ComplaintViewModel model) {
            return Json(GetResponse());
        }
    }// class
}// namespace
