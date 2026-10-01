using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Shared;
using MTAoars.Repositories.Interfaces;
using MTAoars.DomainModels;
using MTAoars.ViewModels.Interfaces;
using MTAoars.ViewModels.Operations;
using MTAoars.Utilities.Constants;
using MTAoars.Utilities.Attributes;

namespace MTAoars.Validators.Operations {
    public class PhotoValidator : IValidator<IExistableCompanyGuarantor> {
        ITbeExemptionRepository tbeExemptionRepository;
        IAgencyRepository agencyRepository;

        public PhotoValidator(IAgencyRepository agencyRepository, ITbeExemptionRepository tbeExemptionRepository)
        {
            this.agencyRepository = agencyRepository;
            this.tbeExemptionRepository = tbeExemptionRepository;
        }

        public IEnumerable<ValidationMessage> Validate(IExistableCompanyGuarantor item)
        {
            var propInfo = item.GetType().GetProperty("PhotoPath");
            var isIgnoreValidate = propInfo.GetCustomAttributes(typeof(IgnoreValidateAttribute), true).Length > 0;

            if (!isIgnoreValidate && string.IsNullOrEmpty(item.PhotoPath))
            {
                yield return new ValidationMessage("", "Please upload photograph");
            }
        }

    }// class
}// namespace
