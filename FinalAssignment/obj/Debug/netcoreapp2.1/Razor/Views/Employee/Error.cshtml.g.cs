#pragma checksum "D:\projects\Office\FinalAssignment\FinalAssignment\Views\Employee\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "78c5ab17ae520b40abde9e6c11df39bacd6525f6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Error), @"mvc.1.0.view", @"/Views/Employee/Error.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Employee/Error.cshtml", typeof(AspNetCore.Views_Employee_Error))]
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
#line 1 "D:\projects\Office\FinalAssignment\FinalAssignment\Views\_ViewImports.cshtml"
using FinalAssignment;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"78c5ab17ae520b40abde9e6c11df39bacd6525f6", @"/Views/Employee/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33ecb20dd5f8b0f9cd9b67d8933eaf9efe74949d", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\projects\Office\FinalAssignment\FinalAssignment\Views\Employee\Error.cshtml"
  
    ViewData["Title"] = "Error";
    Layout = "~/Views/Shared/_MasterLayout.cshtml";

#line default
#line hidden
            BeginContext(96, 6, true);
            WriteLiteral("\r\n<h2>");
            EndContext();
            BeginContext(103, 17, false);
#line 7 "D:\projects\Office\FinalAssignment\FinalAssignment\Views\Employee\Error.cshtml"
Write(TempData["error"]);

#line default
#line hidden
            EndContext();
            BeginContext(120, 9, true);
            WriteLiteral("</h2>\r\n\r\n");
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