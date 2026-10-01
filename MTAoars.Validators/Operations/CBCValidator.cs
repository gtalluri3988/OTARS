using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Shared;
using MTAoars.Repositories.Interfaces;
using MTAoars.DomainModels;
using MTAoars.ViewModels.Interfaces;
using MTAoars.ViewModels.Operations;
using MTAoars.Utilities.Config;
using MTAoars.Utilities.Interfaces;
using MTAoars.Utilities.Mvc;
using MTAoars.Utilities.Constants;

namespace MTAoars.Validators.Operations {
    public class CBCValidator : IValidator<CBCStartViewModel> {
        ICBCRepository cbcRepository;
        IScopeDataProvider dataProvider;

        public CBCValidator(ICBCRepository cbcRepository, IScopeDataProvider dataProvider) {
            this.cbcRepository = cbcRepository;
            this.dataProvider = dataProvider;
        }

        public IEnumerable<ValidationMessage> Validate(CBCStartViewModel item) {
            var identity = dataProvider.Get<Identity>(GlobalConstants.CurrentIdentity);
            if (identity.IsISMOrMTA) yield break;
            var header = cbcRepository.Get(Convert.ToInt32(item.Year.ID), Convert.ToInt32(item.Quarter.ID));
            if (header == null) yield break;
            var code = header.LookupCBCHeaderStatu.Code;
            var description = header.LookupCBCHeaderStatu.Description;
            if (code == LookupConstants.CBCHeaderStatus.Saved || code == LookupConstants.CBCHeaderStatus.Rejected || code == LookupConstants.CBCHeaderStatus.Submitted) yield break;
            yield return new ValidationMessage("", "The CBC details for the year {0} and quarter {1} has been {2}. Further modifications are not allowed. Please contact MTA", item.Year.ID.ToString(), item.Quarter.ID.ToString(), description);
        }

    }// class
}// namespace
