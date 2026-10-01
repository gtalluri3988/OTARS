using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Operations;
using FluentValidation;
using MTAoars.Utilities.IoC;
using MTAoars.Validators.Shared.Fluent;
using MTAoars.ViewModels.Interfaces;
using MTAoars.ViewModels.Reports;

namespace MTAoars.Validators.Operations.Fluents {
    
    [FluentRegisterable]
    public class InvoiceReportValidator : AbstractValidator<InvoiceReportViewModel> {

        public InvoiceReportValidator() {
            RuleFor(x => x.Year).GreaterThan(0);
            RuleFor(x => x.Month).GreaterThan(0);
        }

    }// class
}// namespace
