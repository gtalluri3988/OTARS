using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MTAoars.Utilities.IoC;
using MTAoars.ViewModels.Operations;
using MTAoars.Builders.Interfaces;
using MTAoars.Utilities.Mvc;

namespace MTAoars.Shell.Controllers {
    [MTAoarsAuthorize]
    public class AgencyController : Controller {

        IObjectCreator objectCreator;
        IAgencyBuilder agencyBuilder;

        public AgencyController(IObjectCreator objectCreator, IAgencyBuilder agencyBuilder) {
            this.objectCreator = objectCreator;
            this.agencyBuilder = agencyBuilder;
        }

        public ActionResult Enquiry() {
            var model = objectCreator.Create<EnquiryViewModel>();
            return View(model);
        }

        public ActionResult Details(long id) {
            var model = agencyBuilder.GetAgency(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AjaxList(EnquiryViewModel request) {
            var model = agencyBuilder.Search<AgencySearchResponseViewModel>(request.AgencySearch);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}
