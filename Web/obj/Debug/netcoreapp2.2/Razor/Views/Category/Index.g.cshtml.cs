#pragma checksum "C:\Users\Aleksandar\source\repos\Post\Web\Views\Category\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b0ab200c35199f54368e8742b415226455d3b90"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Category_Index), @"mvc.1.0.view", @"/Views/Category/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Category/Index.cshtml", typeof(AspNetCore.Views_Category_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b0ab200c35199f54368e8742b415226455d3b90", @"/Views/Category/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Category_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Web.Models.CategoryIndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Category\Index.cshtml"
  
     ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(131, 283, true);
            WriteLiteral(@"
    <table class=""table"">
        <thead>
            <tr>
                <th>
                   Id
                </th>
                <th>
                   Name
                </th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 20 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Category\Index.cshtml"
             foreach (var posts in Model.CategoryPosts)
            {

#line default
#line hidden
            BeginContext(486, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(559, 38, false);
#line 24 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Category\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => posts.Id));

#line default
#line hidden
            EndContext();
            BeginContext(597, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(677, 40, false);
#line 27 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Category\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => posts.Name));

#line default
#line hidden
            EndContext();
            BeginContext(717, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(797, 60, false);
#line 30 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Category\Index.cshtml"
                   Write(Html.ActionLink("Details", "Details", new { id = posts.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(857, 28, true);
            WriteLiteral(" |\r\n                        ");
            EndContext();
            BeginContext(886, 54, false);
#line 31 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Category\Index.cshtml"
                   Write(Html.ActionLink("Edit", "Edit", new { id = posts.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(940, 30, true);
            WriteLiteral(" |\r\n\r\n                        ");
            EndContext();
            BeginContext(971, 58, false);
#line 33 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Category\Index.cshtml"
                   Write(Html.ActionLink("Delete", "Delete", new { id = posts.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1029, 55, true);
            WriteLiteral("|\r\n\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 37 "C:\Users\Aleksandar\source\repos\Post\Web\Views\Category\Index.cshtml"

            }

#line default
#line hidden
            BeginContext(1101, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(1113, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b0ab200c35199f54368e8742b415226455d3b906668", async() => {
                BeginContext(1136, 10, true);
                WriteLiteral("Create New");
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
            BeginContext(1150, 36, true);
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Web.Models.CategoryIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
