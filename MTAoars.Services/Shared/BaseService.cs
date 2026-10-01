using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Validators;
using MTAoars.Services.Interfaces;
using MTAoars.DomainModels;
using MTAoars.Repositories.Interfaces;
using Microsoft.Practices.Unity;
using MTAoars.Utilities.Constants;
using MTAoars.ViewModels.Shared;

namespace MTAoars.Services.Shared {

    public class BaseService : IBaseService{

        IValidationProvider validationProvider;
        ServiceContext currentContext;

        public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public BaseService(IValidationProvider validationProvider) {
            this.validationProvider = validationProvider;
            currentContext = new ServiceContext();
        }

        [Dependency]
        public ICompanyRepository CompanyRepository {
            set;
            get;
        }

        [Dependency]
        public IActivityRepository ActivityRepository {
            set;
            get;
        }

        [Dependency]
        public IRepository<AgencyPrincipal> AgencyPrincipalRepository {
            set;
            get;
        }

        protected Company MTACompany {
            get {
                return CompanyRepository.Get(GlobalConstants.MTACompanyCode);
            }
        }

        protected Company ISMCompany {
            get {
                return CompanyRepository.Get(GlobalConstants.ISMCompanyCode);
            }
        }

        protected bool Validate<T>(T item, bool omitMessages = false) {
            var messages = ValidateItem(item).SelectMany(msgList => msgList).Select(msg => msg).ToList();
            if (messages.Count() > 0 && !omitMessages) {
                currentContext.ValidationMessages.AddRange(messages);
            }
            return messages.Count() == 0;
        }
     

        IEnumerable<IEnumerable<ValidationMessage>> ValidateItem<T>(T item,List<Type> skipValidators) {            
            var validators = validationProvider.GetValidators(item);
            foreach (IValidator<T> validator in validators) {                
                yield return validator.Validate(item);
            }
        }


        IEnumerable<IEnumerable<ValidationMessage>> ValidateItem<T>(T item) {
            var validators = validationProvider.GetValidators(item);
            foreach (IValidator<T> validator in validators) {
                yield return validator.Validate(item);
            }
        }

        public ServiceContext CurrentContext {
            get { return currentContext; }
        }

        protected Journal GetJournal(long principalId, string activityCode, string uri)
        {
            var activity = ActivityRepository.Get(activityCode);
            var principal = AgencyPrincipalRepository.Get(principalId);
            var journal = new Journal
            {
                Description = activity.Description,
                Uri = uri,
                AgencyID = principal.AgencyID,
                CompanyID = principal.CompanyID,
                IntermediaryTypeID = principal.IntermediaryTypeID,            
                AgencyNumber = principal.AgencyNumber /*[20191121] - Added AgencyNumber and IsHistorical to identity correct Agent record from Journal */
            };            
            journal.Postings.Add(GetPosting(principal.CompanyID, activity.MTACharge.Value * -1));
            journal.Postings.Add(GetPosting(MTACompany.ID, activity.MTACharge.Value));
            journal.Postings.Add(GetPosting(MTACompany.ID, activity.ISMCharge.Value * -1));
            journal.Postings.Add(GetPosting(ISMCompany.ID, activity.ISMCharge.Value));
            return journal;
        }

        Posting GetPosting(long companyId, decimal amount) {
            return new Posting {
                CompanyID = companyId,
                Amount = amount,
                AccountingMonth = DateTime.Now.Month,
                AccountingYear = DateTime.Now.Year
            };
        }


        protected string GetSortOrder(GridPageViewModel model) {
            if (model.Sort == null || model.Sort.Count == 0) return "1";
            var sb = new StringBuilder();
            foreach (var sort in model.Sort) {
                if (sb.Length > 0) sb.Append(" and ");
                sb.AppendFormat("{0} {1}", sort.Field, sort.Dir);
            }
            return sb.ToString();
        }

        protected string GetSearch(GridPageViewModel model) {
            if (model.Filter == null) return "1=1";
            return GetSearch(model.Filter.Filters, model.Filter.Logic);
        }

        string GetSearch(IEnumerable<GridFilterViewModel> filters, string logic) {
            var sb = new StringBuilder();
            foreach (var filter in filters) {
                if (filter.Filters != null) {
                    sb.AppendFormat(" {0} ({1})", logic, GetSearch(filter.Filters, filter.Logic));
                }
                if (filter.Field != null) {
                    if (sb.Length > 0) sb.AppendFormat(" {0} ", logic);
                    sb.AppendFormat(GetFilter(filter));
                }
            }
            return sb.ToString();
        }

        string GetFilter(GridFilterViewModel filter) {
            string output = "";
            switch (filter.Operator) {
                case "eq":
                    if (filter.Value == "True" || filter.Value == "False") {
                        output = String.Format("= {1}", filter.Field, filter.Value);
                    } else {
                        output = String.Format("= \"{1}\"", filter.Field, filter.Value);
                    }
                    break;
                case "neq":
                    output = String.Format("!= \"{1}\"", filter.Field, filter.Value);
                    break;
                case "contains":
                    output = String.Format(".Contains(\"{1}\")", filter.Field, filter.Value);
                    break;
                case "startswith":
                    output = String.Format(".StartsWith(\"{1}\")", filter.Field, filter.Value);
                    break;
                case "endswith":
                    output = String.Format(".EndsWith(\"{1}\")", filter.Field, filter.Value);
                    break;
            }
            if (filter.Field.Contains("{condition}")) return filter.Field.Replace("{condition}", output);
            return String.Format("{0}{1}", filter.Field, output);
        }

    }// class

}// namespace
