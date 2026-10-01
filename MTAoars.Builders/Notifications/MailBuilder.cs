using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Builders.Interfaces;
using MTAoars.ViewModels.Notifications;
using MTAoars.Repositories.Interfaces;
using MTAoars.DomainModels;
using MTAoars.Utilities.Interfaces;
using MTAoars.ViewModels.Shared;
using MTAoars.Utilities.Constants;

namespace MTAoars.Builders.Notifications {
    public class MailBuilder : IMailBuilder {

        ICompanyRepository companyRepository;
        IScopeDataProvider dataProvider;

        public MailBuilder(ICompanyRepository companyRepository, IScopeDataProvider dataProvider) {
            this.companyRepository = companyRepository;
            this.dataProvider = dataProvider;
        }

        public NewMailViewModel GetNewMail() {
            var model = new NewMailViewModel();
            model.Companies = companyRepository.GetAll().ToLookupItem();
            return model;
        }


      
    }// class
}// namespace
