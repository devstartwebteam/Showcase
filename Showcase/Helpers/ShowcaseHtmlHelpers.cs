using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Showcase.Helpers
{
    public static class ShowcaseHtmlHelpers
    {
        public static MvcHtmlString Image(this HtmlHelper html, byte[] image)
        {
            if (image != null)
            {
                var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
                return new MvcHtmlString("<img style='max-height:100px;width:auto;' src='" + img + "' />");
            }

            return new MvcHtmlString("");
        }
    }
}