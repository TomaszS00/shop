#pragma checksum "C:\Users\Tomasz\Source\Repos\shop\Wsei.Lab3\Views\Metrics\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d49b7d4452c728e146c13b47276fe9ce34339634"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Metrics_Index), @"mvc.1.0.view", @"/Views/Metrics/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Tomasz\Source\Repos\shop\Wsei.Lab3\Views\_ViewImports.cshtml"
using Wsei.Lab3;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Tomasz\Source\Repos\shop\Wsei.Lab3\Views\_ViewImports.cshtml"
using Wsei.Lab3.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d49b7d4452c728e146c13b47276fe9ce34339634", @"/Views/Metrics/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94bfb06836c622f185995c3fafe161011084ab85", @"/Views/_ViewImports.cshtml")]
    public class Views_Metrics_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Wsei.Lab3.Services.EndpointStats>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2>Application metrics</h2>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>HTTP method</th>\r\n            <th>Path</th>\r\n            <th>Request count</th>\r\n        </tr>\r\n    </thead>\r\n\r\n    <tbody>\r\n");
#nullable restore
#line 15 "C:\Users\Tomasz\Source\Repos\shop\Wsei.Lab3\Views\Metrics\Index.cshtml"
         foreach (var stats in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 18 "C:\Users\Tomasz\Source\Repos\shop\Wsei.Lab3\Views\Metrics\Index.cshtml"
               Write(stats.HttpMethod);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 19 "C:\Users\Tomasz\Source\Repos\shop\Wsei.Lab3\Views\Metrics\Index.cshtml"
               Write(stats.RequestUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 20 "C:\Users\Tomasz\Source\Repos\shop\Wsei.Lab3\Views\Metrics\Index.cshtml"
               Write(stats.RequestsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 22 "C:\Users\Tomasz\Source\Repos\shop\Wsei.Lab3\Views\Metrics\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Wsei.Lab3.Services.EndpointStats>> Html { get; private set; }
    }
}
#pragma warning restore 1591
