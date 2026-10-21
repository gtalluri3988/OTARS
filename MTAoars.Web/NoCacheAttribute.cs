using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTAoars.Web
{
    public class NoCacheAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SetNoCacheHeaders(filterContext.HttpContext.Response);
            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            SetNoCacheHeaders(filterContext.HttpContext.Response);
            base.OnResultExecuting(filterContext);
        }

        private static void SetNoCacheHeaders(HttpResponseBase response)
        {
            // Finding 6: prevent sensitive authenticated pages from being restored from browser cache.
            response.Cache.SetCacheability(HttpCacheability.NoCache);
            response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            response.Cache.SetNoStore();
            response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            response.Headers.Set("Cache-Control", "no-store, no-cache, must-revalidate, max-age=0");
            response.Headers.Set("Pragma", "no-cache");
            response.Headers.Set("Expires", "Thu, 01 Jan 1970 00:00:00 GMT");
        }
    }
}
