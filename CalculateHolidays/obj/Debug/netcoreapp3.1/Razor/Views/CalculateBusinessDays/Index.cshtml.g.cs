#pragma checksum "C:\Users\izzyl\source\CalculateHolidays\CalculateHolidays\Views\CalculateBusinessDays\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1fc131cea6b108a9f7cf9db66729e077e28e3f3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CalculateBusinessDays_Index), @"mvc.1.0.view", @"/Views/CalculateBusinessDays/Index.cshtml")]
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
#line 1 "C:\Users\izzyl\source\CalculateHolidays\CalculateHolidays\Views\_ViewImports.cshtml"
using CalculateHolidays;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\izzyl\source\CalculateHolidays\CalculateHolidays\Views\_ViewImports.cshtml"
using CalculateHolidays.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fc131cea6b108a9f7cf9db66729e077e28e3f3e", @"/Views/CalculateBusinessDays/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"388790450fdfc930d1c6743634943b52eb5ef690", @"/Views/_ViewImports.cshtml")]
    public class Views_CalculateBusinessDays_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CalculateHolidays.Models.CalculateBusinessDays>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Calculate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jqueryui/jquery-ui.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jqueryui/jquery-ui.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\izzyl\source\CalculateHolidays\CalculateHolidays\Views\CalculateBusinessDays\Index.cshtml"
  
    ViewData["Title"] = "Calculate";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Calculate Business Days</h1>
<h2>Welcome! Dear guest</h2>
<p>May you live in your dream!</p>
<p>This page provide you the magic to calculate business days between <strong>01/01/2021</strong> to <strong>31/12/2030</strong></p>
<p>Choose the period (start and end ), click your preferred button to get results</p>
<p>The result will exclude the start date and end date</p>
<p>The result will exclude Weekends and public holidays (Australia Nationwide)</p>
<p><strong>The calculation assumes that Monday to Friday are workdays</strong></p>

<div style=""margin-top:20px; margin-bottom:20px"">
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1fc131cea6b108a9f7cf9db66729e077e28e3f3e6135", async() => {
                WriteLiteral("\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n                <h4>Input your start date and end date</h4>\r\n            </div>\r\n            <div class=\"row\">\r\n                ");
#nullable restore
#line 23 "C:\Users\izzyl\source\CalculateHolidays\CalculateHolidays\Views\CalculateBusinessDays\Index.cshtml"
           Write(Html.Label("Start Date", null, new { @class = "control-label col-sm-3" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                <div class=\"col-sm-3\">\r\n                    ");
#nullable restore
#line 25 "C:\Users\izzyl\source\CalculateHolidays\CalculateHolidays\Views\CalculateBusinessDays\Index.cshtml"
               Write(Html.TextBoxFor(model => model.startDate, "{dd/mm/yyyy}", new { @class = "datepicker", @name="startDate" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                ");
#nullable restore
#line 27 "C:\Users\izzyl\source\CalculateHolidays\CalculateHolidays\Views\CalculateBusinessDays\Index.cshtml"
           Write(Html.Label("End Date", null, new { @class = "control-label col-sm-3" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                <div class=\"col-sm-3\">\r\n                    ");
#nullable restore
#line 29 "C:\Users\izzyl\source\CalculateHolidays\CalculateHolidays\Views\CalculateBusinessDays\Index.cshtml"
               Write(Html.TextBoxFor(model => model.endDate, "{dd/mm/yyyy}", new { @class = "datepicker", @name="endDate" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"row\" style=\"margin-top:30px;\">\r\n                <div class=\"col-sm-1\">Results</div>\r\n                <div class=\"col-sm-11\">\r\n              \r\n                    <p><strong> ");
#nullable restore
#line 36 "C:\Users\izzyl\source\CalculateHolidays\CalculateHolidays\Views\CalculateBusinessDays\Index.cshtml"
                           Write(TempData["ResultMessage"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" </strong></p>

                </div>
            </div>
            <div class=""row"" style=""margin-top:30px;"">
                <h4>Choose your preferred button:</h4>
            </div>
            <div class=""row"">
                <div class=""col-sm-3"">

                    <button class=""btn-primary"" type=""submit"" name=""action"" value=""Default"">Get Business Days</button>
                </div>
                <div class=""col-sm-3"">
                    <button class=""btn-primary"" type=""submit"" name=""action"" value=""GetWorkDays"">Get Week Days</button>
                </div>
                <div class=""col-sm-3"">
                    <button class=""btn-primary"" type=""submit"" name=""action"" value=""GetWorkDaysFixedHoliday"">Get Business Days (Fixed Holiday)</button>
                </div>
                <div class=""col-sm-3"">
                    <button class=""btn-primary"" type=""submit"" name=""action"" value=""GetWorkDaysDynamicHoliday"">Get Business Days (Dynamic Holiday)</button>
                <");
                WriteLiteral(@"/div>
            </div>
            <div class=""row"">
                <div class=""col-sm-3"">
                    <h4>Default (Use Nager.Date to get Australia Public Holidays - in NSW)</h4>
                    <p>Use C# we need to calculate business days between two dates considering multiple factors (OOOps)</p>
                    <p>Only take into consideration of Australia and NSW public holiday, could be extended</p>
                    <p>The soltuion should be a web application and should also be testable</p>
                </div>
                <div class=""col-sm-3"">
                    <h4>Week days between two days</h4>
                    <p>
                        We are looking to calculate the number of week days between two dates.
                        Assume week days are Monday to Friday.
                        The returned count should not include from date or to date.
                        Examples:
                        - Thurs 7/8/2014 to Mon 11/8/2014 should retu");
                WriteLiteral(@"rn 1
                        - Wed 13/8/2014 to Thurs 21/8/2014 should return 5
                    </p>
                </div>
                <div class=""col-sm-3"">
                    <h4>Business Days between two days (considering fixed holidays)</h4>
                    <p>
                        Extend the solution to calculate number of days between two dates. Considering week days are
                        Mon – Fri. and existing list of fixed public holidays.
                        The returned count should not include from date or to date.
                        The list of public holidays (configurable) are for example:
                        - 1/1/2021
                        - 26/1/2021
                        - 1/6/2021
                        -25/12/2021
                        Example:
                        - Wed 13/8/2014 to Thurs 21/8/2014 should return 4
                    </p>
                </div>
                <div class=""col-sm-3"">
                    <h4");
                WriteLiteral(@">Business Days between two days (Dynamic Holidays)</h4>
                    <p>
                        Public holidays are a little bit more complex than simple fixed list of dates, basically three types
                        of holidays
                        1. Always on the same day even if it is a week end (like Anzac Day 25 April every year).
                        2. On the same day as far as it is not a week end (like New Year 1st of every year unless it is a
                        week end, then the holiday would be next Monday).
                        3. Certain occurrence on a certain day in month (like Queen’s Birthday on the second Monday
                        in June every year).
                        Extend the solution to cater for these types of holidays. State which holidays you have added to
                        your solution.
                        Rules:
                        New Year 1/1 - Move to next Monday
                        Australia Day 26/1 - Fixed");
                WriteLiteral(" Date\r\n                        Christmas 25/12 - Fixed Date\r\n                        \r\n                    </p>\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1fc131cea6b108a9f7cf9db66729e077e28e3f3e14408", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1fc131cea6b108a9f7cf9db66729e077e28e3f3e15587", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1fc131cea6b108a9f7cf9db66729e077e28e3f3e16687", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    <script type=\"text/javascript\">\r\n        $(\'.datepicker\').datepicker({\r\n            dateFormat: \'dd-MM-yy\',\r\n            changeMonth: true,\r\n            changeYear: true,\r\n            yearRange: \"0:+9\"\r\n        });\r\n    </script>\r\n\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CalculateHolidays.Models.CalculateBusinessDays> Html { get; private set; }
    }
}
#pragma warning restore 1591
