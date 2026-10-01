using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Notifications;

namespace MTAoars.ViewModels.Interfaces {
    public interface IExistableTerminationList {

        List<TerminatedVariableSource> TerminationList { get; }

    }// interface
}// namespae
