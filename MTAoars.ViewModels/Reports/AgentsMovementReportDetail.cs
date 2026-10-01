using System;

namespace MTAoars.ViewModels.Reports
{
    /// <summary>
    /// Row model for the Agents Movement Report (RDLC dataset).
    /// </summary>
    public class AgentsMovementReportDetail
    {
        /// <summary>1-based row index in the report (serial number).</summary>
        public int SerialNo { get; set; }

        public string AgentAgency { get; set; }
        public string RegistrationType { get; set; }
        public string IntermediaryType { get; set; }
        public string NomineePrincipal { get; set; }
        /// <summary>NRIC / IC of the corporate nominee (from linked Member when present).</summary>
        public string CorporateNomineeNricNumber { get; set; }
        public string TakafulOperator { get; set; }
        public DateTime? DateAppointed { get; set; }
        public DateTime? DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public string PreviousTakafulOperator { get; set; }
        public DateTime? DateTerminated { get; set; }
    }
}
