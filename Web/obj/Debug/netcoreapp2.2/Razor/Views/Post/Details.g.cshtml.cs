#pragma checksum "C:\Users\Aleksandar\source\repos\Post\Web\Views\Post\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "960f3e63fe51d0ef9485a650fafc558fbcb941fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Post_Details), @"mvc.1.0.view", @"/Views/Post/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Post/Details.cshtml", typeof(AspNetCore.Views_Post_Details))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Aleksandar\source\repos\Post\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#line 2 "C:\Users\Aleksandar\source\repos\Post\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"960f3e63fe51d0ef9485a650fafc558fbcb941fc", @"/Views/Post/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Post_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Aplication.DTO.OnePostDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(34, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Post\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(79, 131, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>OnePostDto</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(211, 38, false);
#line 14 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Post\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(249, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(311, 34, false);
#line 17 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Post\Details.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(345, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(406, 40, false);
#line 20 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Post\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(446, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(508, 36, false);
#line 23 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Post\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(544, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(605, 40, false);
#line 26 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Post\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Text));

#line default
#line hidden
            EndContext();
            BeginContext(645, 71, true);
            WriteLiteral("\r\n        </dt>\r\n        \r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(717, 36, false);
#line 30 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Post\Details.cshtml"
       Write(Html.DisplayFor(model => model.Text));

#line default
#line hidden
            EndContext();
            BeginContext(753, 17, true);
            WriteLiteral("\r\n        </dd>\r\n");
            EndContext();
#line 32 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Post\Details.cshtml"
         foreach (var p in ViewBag.Comments)
        {
            

#line default
#line hidden
            BeginContext(840, 9, false);
#line 34 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Post\Details.cshtml"
       Write(p.Comment);

#line default
#line hidden
            EndContext();
#line 34 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Post\Details.cshtml"
                      
        }

#line default
#line hidden
            BeginContext(862, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 36 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Post\Details.cshtml"
         foreach (var s in ViewBag.Pictures)
        {


#line default
#line hidden
            BeginContext(921, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(933, 31, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "960f3e63fe51d0ef9485a650fafc558fbcb941fc7319", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 943, "~/uploads/", 943, 10, true);
#line 39 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Post\Details.cshtml"
AddHtmlAttributeValue("", 953, s.Name, 953, 7, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(964, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 40 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Post\Details.cshtml"
        }

#line default
#line hidden
            BeginContext(977, 30, true);
            WriteLiteral("    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1008, 68, false);
#line 44 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Post\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1076, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1084, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "960f3e63fe51d0ef9485a650fafc558fbcb941fc9508", async() => {
                BeginContext(1106, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1122, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Aplication.DTO.OnePostDto> Html { get; private set; }
    }
}
#pragma warning restore 1591