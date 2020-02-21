using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace Showcase.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RateLimitAttribute : ActionFilterAttribute, IActionFilter
    {
        public int MilliSeconds { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string key = string.Join("-", filterContext.HttpContext.Request.HttpMethod, filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, filterContext.ActionDescriptor.ActionName, filterContext.HttpContext.Request.UserHostAddress);
            bool flag = false;
            if (HttpRuntime.Cache[key] == null)
            {
                HttpRuntime.Cache.Add(key, (object)true, (CacheDependency)null, DateTime.Now.AddMilliseconds((double)this.MilliSeconds), Cache.NoSlidingExpiration, CacheItemPriority.Low, (CacheItemRemovedCallback)null);
                flag = true;
            }
            if (flag)
                return;
            filterContext.Result = (ActionResult)new ContentResult()
            {
                Content = "We have blocked your request due a high number of page requests from your network over a short period of time. Please wait a few moments and try again."
            };
            filterContext.HttpContext.Response.StatusCode = 429;
        }
    }
}