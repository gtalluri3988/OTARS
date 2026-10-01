using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Interfaces;

namespace MTAoars.Services.Interfaces {
    public interface INotificaitonService {

        bool Notify(long fromCompanyId, long toCompanyId, string notificationCode, INotificationVariableSource variableSource);

    }// interface
}// class
