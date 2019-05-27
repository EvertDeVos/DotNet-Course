using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.TagHelpers
{
    [HtmlTargetElement("email", TagStructure = TagStructure.WithoutEndTag)]
    public class EmailTaghelper : TagHelper
    {
        private const string Domain = "realdolmen.com";
        public string MailTo { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var address = $"{MailTo}@{Domain}";
            output.Attributes.Add(new TagHelperAttribute("href", $"mailto:{address}"));
            output.Content.SetContent($"{address}");
        }
    }
}
