using MTAoars.ViewModels.Operations;
using System.Collections.Generic;
using System.IO;

namespace MTAoars.Builders.Interfaces {
    public interface ITerminationBuilder : IBaseBuilder {
        
        TerminationSearchResponseViewModel Search(string agencyNumber);
        IEnumerable< TerminationSearchResponseViewModel> Search(Stream stream);
        TerminationSearchResponseViewModel SearchRecovery(string agencyNumber);
        IEnumerable<TerminationSearchResponseViewModel> SearchRecovery(Stream stream);

    }// interface
}// namespace
