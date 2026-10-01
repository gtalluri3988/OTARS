using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MTAoars.Utilities.IoC;
using MTAoars.ViewModels.Operations;
using MTAoars.Builders.Interfaces;
using MTAoars.Utilities.Mvc;
using MTAoars.ViewModels.Maintenance;
using MTAoars.Services.Interfaces;
using System.Threading.Tasks;
using MTAoars.Utilities.Constants;

namespace MTAoars.Web.Controllers {

    [MTAoarsAuthorize]
    public class UploadController : Controller {

        IObjectCreator objectCreator;
        IAgencyBuilder agencyBuilder;
        IUploadService uploadService;

        public UploadController(IObjectCreator objectCreator, IAgencyBuilder agencyBuilder, IUploadService uploadService) {
            this.objectCreator = objectCreator;
            this.agencyBuilder = agencyBuilder;
            this.uploadService = uploadService;
        }

        public ActionResult Ibfim() {
            var model = new UploadViewModel {
                Caption = "Select file to upload IBFIM result",
                Code = LookupConstants.Uploads.Ibfim, FileControlID = "ibfimList", PostAction = "Ibfim"
            }; 
            return View("Excel", model);
        }

        [HttpPost]
        public ActionResult Ibfim([ModelBinder(typeof(ExcelModelBinder))]ExcelList<IbfimExcelViewModel> ibfimList) {
            /*Task.Factory.StartNew(() => {
                uploadService.UploadIbfim(ibfimList);
            });*/
            uploadService.UploadIbfim(ibfimList);
            return RedirectToAction("Complete", new { Code = LookupConstants.Uploads.Ibfim });
        }

        [HttpGet]
        public ActionResult RegistrationFile() {
            var model = new UploadViewModel {
                Caption = "Select file to upload Bulk Registration",
                Code = LookupConstants.Uploads.Registration,
                FileControlID = "registrationList",
                PostAction = "RegistrationFile"
            };
            return View("Excel", model);
        }

        [HttpPost]
        public ActionResult RegistrationFile([ModelBinder(typeof(ExcelModelBinder))]ExcelList<RegistrationExcelViewModel> registrationList) {
           /* Task.Factory.StartNew(() => {
                uploadService.UploadIbfim(ibfimList);
            });
            return RedirectToAction("Complete", new { Code = LookupConstants.Uploads.Ibfim });*/
          
            registrationList.ForEach(r => { r.IsOld = Request["is-Old"] == "on" ? true : false; });
            uploadService.UploadRegistration(registrationList);
            return RedirectToAction("Complete", new { Code = LookupConstants.Uploads.Ibfim });
        }

        public ActionResult History() {
            return View();
        }

        public ActionResult Complete(string code) {
            return View((object)code);
        }

        public ActionResult Error() {
            return View();
        }

        public ActionResult RawContent(long id) {
            var path = uploadService.GetHistoryRawPath(id);
            return new FilePathResult(path, "text/csv");
        }

        public ActionResult SuccessContent(long id) {
            var path = uploadService.GetHistorySuccessPath(id);
            return new FilePathResult(path, "text/csv");
        }

        public ActionResult ErrorContent(long id) {
            var path = uploadService.GetHistoryErrorPath(id);
            return new FilePathResult(path, "text/csv");
        }

    }// class
}// namespace

