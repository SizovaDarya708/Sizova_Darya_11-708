#pragma checksum "C:\Users\darya\source\repos\NoteStorage\NoteStorage\Views\NoteStorage\EditNote.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "838313f5492141b2a8b203db9e0e0b23b40e31d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NoteStorage_EditNote), @"mvc.1.0.view", @"/Views/NoteStorage/EditNote.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/NoteStorage/EditNote.cshtml", typeof(AspNetCore.Views_NoteStorage_EditNote))]
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
#line 1 "C:\Users\darya\source\repos\NoteStorage\NoteStorage\Views\_ViewImports.cshtml"
using NoteStorage;

#line default
#line hidden
#line 2 "C:\Users\darya\source\repos\NoteStorage\NoteStorage\Views\_ViewImports.cshtml"
using NoteStorage.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"838313f5492141b2a8b203db9e0e0b23b40e31d9", @"/Views/NoteStorage/EditNote.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9550ce955e5b89365a0f2d7d493d3622f9df26b7", @"/Views/_ViewImports.cshtml")]
    public class Views_NoteStorage_EditNote : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/NoteStorage/EditNote/"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\darya\source\repos\NoteStorage\NoteStorage\Views\NoteStorage\EditNote.cshtml"
  
    ViewData["Title"] = "EditNote";

#line default
#line hidden
            BeginContext(46, 19, true);
            WriteLiteral("<h2>EditNote</h2>\r\n");
            EndContext();
            BeginContext(65, 871, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ea0a76673c74cdba5bb49fdaec38509", async() => {
                BeginContext(103, 437, true);
                WriteLiteral(@"
    <style>
        form {
            height: 2000px;
            background-image: url(https://html5book.ru/wp-content/uploads/2015/10/background56.jpg)
        }
        textarea {
            width: 400px;
            height: 200px
        }
    </style>
    <table>
        <tr>
            <td>
                <label for=""name"">Name</label>
            </td>

            <td>
                <input type=""text""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 540, "\"", 565, 1);
#line 24 "C:\Users\darya\source\repos\NoteStorage\NoteStorage\Views\NoteStorage\EditNote.cshtml"
WriteAttributeValue("", 548, ViewData["Name"], 548, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(566, 222, true);
                WriteLiteral("  name=\"name\" />\r\n            </td>\r\n        </tr>\r\n\r\n        <tr>\r\n            <td>\r\n                <label\" for=\"text\">Text</\">\r\n            </td>\r\n\r\n            <td>\r\n                <textarea typeof=\"text\" name=\"text\">");
                EndContext();
                BeginContext(789, 16, false);
#line 34 "C:\Users\darya\source\repos\NoteStorage\NoteStorage\Views\NoteStorage\EditNote.cshtml"
                                               Write(ViewData["text"]);

#line default
#line hidden
                EndContext();
                BeginContext(805, 124, true);
                WriteLiteral("</textarea>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n    <a href=\"/NoteStorage/SavedNote/\" class=\"active\">Save</a>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(936, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591