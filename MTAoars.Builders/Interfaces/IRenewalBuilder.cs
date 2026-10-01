using MTAoars.ViewModels.Administrative;
using MTAoars.ViewModels.Operations;
using System.Collections.Generic;
using System.IO;

namespace MTAoars.Builders.Interfaces {
    public interface IRenewalBuilder {

        IEnumerable<RenewalListViewModel> GetRenewalHeaderList();

        RenewalHeaderViewModel GetRenewlHeader(long id);

        RenewalHeaderViewModel GetRenewlHeader(RenewalApproveHeaderViewModel approveHeader);

        RenewalHeaderViewModel GetRenewalDetails(Stream stream,int year,int quarter);

        RenewalDetailsViewModel GetRenewalHeaderByCompany(long companyID);

        RenewalDetailsViewModel GetRenewalHeaderRef(long id);
    }// interface
}// namespace
