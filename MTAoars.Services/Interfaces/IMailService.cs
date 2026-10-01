using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Notifications;
using MTAoars.ViewModels.Shared;

namespace MTAoars.Services.Interfaces {
    
    public interface IMailService : IBaseService {

        MailListViewModel GetReceivedMails(GridPageViewModel model);

        MailListViewModel GetSentMails(GridPageViewModel model);

        MailViewModel Read(long id);

        MailReplyViewModel GetReplyMail(long id);

        void Send(MailReplyViewModel model);

        void Send(NewMailViewModel model);
    }// interface

}// namespace
