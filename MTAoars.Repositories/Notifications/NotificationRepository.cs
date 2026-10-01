using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Repositories.Interfaces;
using MTAoars.Repositories.Shared;
using MTAoars.DomainModels;

namespace MTAoars.Repositories.Notifications {

    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository {

        public NotificationRepository(EntityContext context)
            : base(context) {
        }

        public Notification Get(string code) {
            return Context.Notifications.SingleOrDefault(p => p.Code == code);
        }

    }// class

}// namespace
