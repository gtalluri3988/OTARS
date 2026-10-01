using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Notifications;

namespace MTAoars.Builders.Interfaces {
    public interface IMailBuilder {

        NewMailViewModel GetNewMail();

    }
}
