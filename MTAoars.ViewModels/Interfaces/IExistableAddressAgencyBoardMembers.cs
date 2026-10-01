using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Shared;

namespace MTAoars.ViewModels.Interfaces {
    public interface IExistableAddressAgencyBoardMembers : IExistableAgency, IExistableBoardMembers{

        AddressViewModel Address { get; set; }
    }
}
