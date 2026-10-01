using MTAoars.Utilities.Interfaces;
using MTAoars.Utilities.IoC;
using MTAoars.Utilities.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace MTAoars.Utilities
{
    public class CurrentUser
    {
        public CurrentUser()
        {
        }

        public Identity GetCurrentIdentity()
        {
            var dataProvider = ObjectContainer.Container.Resolve<IScopeDataProvider>();
            var identity = dataProvider.Get<Identity>(MTAoars.Utilities.Constants.GlobalConstants.CurrentIdentity);
            return identity;
        }

        public bool IsLogin
        {
            get
            {
                var currentIdentity = GetCurrentIdentity();
                return (currentIdentity != null);
            }
        }
    }
}
