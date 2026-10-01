using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MTAoars.ViewModels.Shared;
using MTAoars.Services.Interfaces;
using MTAoars.Utilities.Mvc;

namespace MTAoars.Shell.Controllers {
    [MTAoarsAuthorize]
    public class InvoiceController : Controller {

        IInvoiceService invoiceService;

        public InvoiceController(IInvoiceService invoiceService) {
            this.invoiceService = invoiceService;
        }

        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult PagedList(GridPageViewModel input) {
            var model = invoiceService.GetInvoiceList(input);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail(long id) {
            var model = invoiceService.GetInvoiceDetails(id);
            return PartialView(model);
        }

    }// class
}// namespace
