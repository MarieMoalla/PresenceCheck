#pragma checksum "C:\Users\Marie\Desktop\IMC\PresenceCheck\PresenceCheck\Views\Meetings\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf18863ffee07739a7f1f0345d05541de7ee0096"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Meetings_Edit), @"mvc.1.0.view", @"/Views/Meetings/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf18863ffee07739a7f1f0345d05541de7ee0096", @"/Views/Meetings/Edit.cshtml")]
    public class Views_Meetings_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PresenceCheck.Entities.Meeting>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Marie\Desktop\IMC\PresenceCheck\PresenceCheck\Views\Meetings\Edit.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Edit</h1>

<h4>Meeting</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Edit"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <input type=""hidden"" asp-for=""id"" />
            <div class=""form-group"">
                <label asp-for=""title"" class=""control-label""></label>
                <input asp-for=""title"" class=""form-control"" />
                <span asp-validation-for=""title"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""date"" class=""control-label""></label>
                <input asp-for=""date"" class=""form-control"" />
                <span asp-validation-for=""date"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""state"" class=""control-label""></label>
                <select asp-for=""state"" class=""form-control""></select>
                <span asp-validation-for=""state""");
            WriteLiteral(@" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""memberId"" class=""control-label""></label>
                <select asp-for=""memberId"" class=""form-control"" asp-items=""ViewBag.memberId""></select>
                <span asp-validation-for=""memberId"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Save"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 48 "C:\Users\Marie\Desktop\IMC\PresenceCheck\PresenceCheck\Views\Meetings\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PresenceCheck.Entities.Meeting> Html { get; private set; }
    }
}
#pragma warning restore 1591
