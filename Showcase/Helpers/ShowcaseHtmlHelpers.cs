using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Showcase.Helpers
{
    public class CheckboxList
    {
        public MultiSelectList List { get; set; }
        public string PropertyName { get; set; }
        public string CssClasses { get; set; }
    }
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

        public static MvcHtmlString TopCarouselImage(this HtmlHelper html, byte[] image)
        {
            if (image != null)
            {
                var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
                return new MvcHtmlString("<img class='ds-top-carousel-img img-fluid' src='" + img + "' />");
            }

            return new MvcHtmlString("");
        }
        public static MvcHtmlString ThumbImage(this HtmlHelper html, byte[] image)
        {
            if (image != null)
            {
                var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
                return new MvcHtmlString("<img class='ds-thumb-img img-fluid' src='" + img + "' />");
            }

            return new MvcHtmlString("");
        }

        public static MvcHtmlString BottomImage(this HtmlHelper html, byte[] image)
        {
            if (image != null)
            {
                var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
                return new MvcHtmlString("<img class='ds-bottom-img img-fluid' src='" + img + "' />");
            }

            return new MvcHtmlString("");
        }
        public static MvcHtmlString SliderImage(this HtmlHelper html, byte[] image)
        {
            if (image != null)
            {
                var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
                return new MvcHtmlString("<img class='ds-slider-img img-fluid' src='" + img + "' />");
            }
            return new MvcHtmlString("");
        }

        public static CheckboxList GetCheckboxList(string property, string cssClasses, MultiSelectList list)
        {
            CheckboxList checkboxList = new CheckboxList();
            checkboxList.PropertyName = property;
            checkboxList.List = list;
            checkboxList.CssClasses = cssClasses;

            return checkboxList;
        }
    }
}