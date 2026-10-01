using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Data.EntityClient;
using MTAoars.Utilities.Config;
using MTAoars.Utilities.Constants;
using MTAoars.DomainModels;

namespace MTAoars.Repositories.Reports {
    
    public class AsciiReportRepository : IReportRepository{

        EntityContext context;
        public AsciiReportRepository(EntityContext context) {
            this.context = context;
        }

        public Dictionary<string, IEnumerable<dynamic>> GetData(Dictionary<string, string> parameters) {
            var fromDate = DateTime.Parse(parameters["FromDate"]);
            var toDate = DateTime.Parse(parameters["ToDate"]);
            bool? inclusionParam = null;
            var isInclusion = parameters["IsInclusion"];
            if (isInclusion == "0" || isInclusion == "1") inclusionParam = isInclusion == "1";
            var output = new Dictionary<string, IEnumerable<dynamic>>();
            output.Add(LookupConstants.Reports.Ascii, context.GetAsciiReport(fromDate, toDate, inclusionParam));
            return output;
        }


        public Dictionary<string, string> GetParameters(Dictionary<string, string> parameters) {
            var output = new Dictionary<string, string>();
            output.Add("FromDate", DateTime.Parse(parameters["FromDate"]).ToShortDateString());
            output.Add("ToDate", DateTime.Parse(parameters["ToDate"]).ToShortDateString());
            return output;
        }

    }// class

}// namespace
