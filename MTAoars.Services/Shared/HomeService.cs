using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Services.Interfaces;
using MTAoars.Repositories.Interfaces;
using MTAoars.DomainModels;
using MTAoars.ViewModels.Shared;
using MTAoars.Utilities.Constants;
using MTAoars.Utilities.Interfaces;
using AutoMapper;
using MTAoars.ViewModels.Notifications;
using MTAoars.Utilities.Mvc;

namespace MTAoars.Services.Shared {
    public class HomeService : IHomeService {

        ILookupRepository lookupRepository;
        IMailRepository mailRepository;
        IRenewalRepository renewalRepository;
        IInvoiceRepository  invoiceRepository;
        IScopeDataProvider dataProvider;

        public HomeService(ILookupRepository lookupRepository, IMailRepository mailRepository, IRenewalRepository renewalRepository, IInvoiceRepository invoiceRepository, IScopeDataProvider dataProvider) {
            this.lookupRepository = lookupRepository;
            this.mailRepository = mailRepository;
            this.renewalRepository = renewalRepository;
            this.invoiceRepository = invoiceRepository;
            this.dataProvider = dataProvider;
        }



        public HomeViewModel GetModel() {
            var model = new HomeViewModel();
            var identity = dataProvider.Get<Identity>(GlobalConstants.CurrentIdentity);
            var statusId = lookupRepository.Get<LookupMailStatus>(LookupConstants.MailStatus.New).ID;
            model.TotalMail = mailRepository.GetReceivedMailsCount(identity.CompanyID, statusId);
            if(identity.IsISMOrMTA) {
                model.TotalRenewal = renewalRepository.GetRenewalDetailsCount(true);
                model.TotalInvoice = invoiceRepository.GetUnpaidInvoiceCount();
            }else {
                model.TotalRenewal = renewalRepository.GetRenewalDetailsCount(false, identity.CompanyID);
                model.TotalInvoice = invoiceRepository.GetUnpaidInvoiceCount(identity.CompanyID);
            }
            var mails = mailRepository.GetReceivedMails(identity.CompanyID, statusId);
            foreach (var mail in mails) {
               var item =  Mapper.Map<MailViewModel>(mail);
               model.Mails.Add(item);
            }
            return model;
        }
    }// class
}// namespace
