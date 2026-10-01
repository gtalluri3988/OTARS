using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Repositories.Interfaces;
using MTAoars.Utilities.Mvc;
using MTAoars.ViewModels.Maintenance;

namespace MTAoars.Services.Interfaces {
    public interface IUploadService : IBaseService {

        void UploadIbfim(ExcelList<IbfimExcelViewModel> items);

        void UploadRegistration(ExcelList<RegistrationExcelViewModel> items);

        string GetHistoryErrorPath(long id);

        string GetHistorySuccessPath(long id);

        string GetHistoryRawPath(long id);

    }// interface
}// 
