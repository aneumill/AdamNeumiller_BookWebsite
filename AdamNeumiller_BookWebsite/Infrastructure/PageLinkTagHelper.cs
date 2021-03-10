
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdamNeumiller_BookWebsite.Models;

//This is the tag helper for the project, the class dynamically creates tags for the project. 

namespace AdamNeumiller_BookWebsite.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        //Dynamaically chagnes the URL for get requests
        private IUrlHelperFactory urlHelperFactory;


        //Setter Method the IURLHelperFactory
        public PageLinkTagHelper (IUrlHelperFactory hp)
        {
            //Set to the passed variable to hp 
            urlHelperFactory = hp;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        //Brings in the Paging Info cs model
        public PagingInfo PageModel { get; set;  }

        public string PageAction { get; set; }
        [HtmlAttributeName(DictionaryAttributePrefix ="page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }



        //Overriding the method i.e. replace with our info
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Set the passed variable
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder result = new TagBuilder("div"); 

            //Loop that dynamically builds for every page, page naviagtion (to the HTML
            for (int i=1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");

                PageUrlValues["pageNum"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction, 
                    PageUrlValues);
                //dynamically update the CSS bootstrap if enabled = true
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }

            //Output that sucker 
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
