using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Utilities.Interfaces;
using System.Web;
using MTAoars.Utilities.Constants;

namespace MTAoars.Utilities.Mvc {
    public class SessionScopeDataProvider : IScopeDataProvider {

        public void Remove(string key) {
            UnregisterActiveSession(key);
            if (HasRegistered(key)) { HttpContext.Current.Session.Remove(key); }
        }

        public void Register<T>(string key, T item) where T:class {
            if (item == null) {
                Remove(key);
                return;
            }

            HttpContext.Current.Session[key] = item;
            // Finding 12: registering a login replaces the active server session for this user.
            RegisterActiveSession(key, item);
        }

        public T Get<T>(string key) where T:class{
            var value = HttpContext.Current.Session[key];
            return (T)(value);
        }

        public bool HasRegistered(string key) {
            object o = Get<object>(key);
            if (o == null) return false;
            // Finding 12: reject older simultaneous sessions after a newer login occurs.
            if (!IsActiveSession(key, o)) {
                HttpContext.Current.Session.Remove(key);
                return false;
            }
            return true;
        }

        private static void RegisterActiveSession<T>(string key, T item) where T : class {
            if (key != GlobalConstants.CurrentIdentity) return;

            var identity = item as Identity;
            if (identity == null) return;

            var context = HttpContext.Current;
            if (context == null || context.Application == null || context.Session == null) return;

            context.Application.Lock();
            try {
                context.Application[GetActiveSessionKey(identity.UserID)] = context.Session.SessionID;
            } finally {
                context.Application.UnLock();
            }
        }

        private static void UnregisterActiveSession(string key) {
            // Finding 5: logout removes the backend active-session marker when this session owns it.
            if (key != GlobalConstants.CurrentIdentity) return;

            var context = HttpContext.Current;
            if (context == null || context.Application == null || context.Session == null) return;

            var identity = context.Session[key] as Identity;
            if (identity == null) return;

            var activeSessionKey = GetActiveSessionKey(identity.UserID);
            context.Application.Lock();
            try {
                // Check and remove under the same lock. Otherwise a newer login can
                // replace the marker between the check and removal and be logged out
                // by the older session finishing its logout request.
                var activeSessionId = context.Application[activeSessionKey] as string;
                if (activeSessionId == context.Session.SessionID)
                    context.Application.Remove(activeSessionKey);
            } finally {
                context.Application.UnLock();
            }
        }

        private static bool IsActiveSession(string key, object item) {
            if (key != GlobalConstants.CurrentIdentity) return true;

            var identity = item as Identity;
            if (identity == null) return false;

            var context = HttpContext.Current;
            if (context == null || context.Application == null || context.Session == null) return false;

            var activeSessionId = context.Application[GetActiveSessionKey(identity.UserID)] as string;
            return string.Equals(activeSessionId, context.Session.SessionID, StringComparison.Ordinal);
        }

        private static string GetActiveSessionKey(long userId) {
            return "MTAoars.ActiveSession." + userId;
        }

    }// class
}// namespace
