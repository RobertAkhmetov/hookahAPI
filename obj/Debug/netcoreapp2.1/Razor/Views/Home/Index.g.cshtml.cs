#pragma checksum "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16ed56e6b8b7639c8d7b270367fb6bc154b996a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16ed56e6b8b7639c8d7b270367fb6bc154b996a5", @"/Views/Home/Index.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApiForHookahv1._0.Models.Hooka>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(84, 29, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(113, 119, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6bc7ddb194af4e1687cb908601a4f7fe", async() => {
                BeginContext(119, 106, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Простой список кальянных</title>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(232, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(236, 1630, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1970559e45cf4340877233f308d6ca4a", async() => {
                BeginContext(242, 738, true);
                WriteLiteral(@"
    <h3>Кальянные в заданной локации</h3>

    <table border=""1"">
        <tr>
            <th>Id</th>
            <th>Название</th>
            <th>Средняя цена кальяна</th>
            <th>ссылка на заставку</th>
            <th>широта</th>
            <th>долгота</th>

            <th>дата открытия</th>
            <th>когда залили</th>
            <th>дата открытия</th>
            <th>когда залил</th>
            <th>адрес</th>
            <th>вк</th>
            <th>инста</th>
            <th>одноклассники</th>
            <th>оценка кальяна</th>
            <th>оценка атмосферы</th>
            <th>оценка кухни</th>
            <th>рейтинг ревью</th>
            <th>просмотры</th>
        </tr>
");
                EndContext();
#line 41 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
         foreach (var hooka in Model)
        {

#line default
#line hidden
                BeginContext(1030, 30, true);
                WriteLiteral("        <tr>\r\n            <td>");
                EndContext();
                BeginContext(1061, 8, false);
#line 44 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.Id);

#line default
#line hidden
                EndContext();
                BeginContext(1069, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1093, 11, false);
#line 45 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.Title);

#line default
#line hidden
                EndContext();
                BeginContext(1104, 24, true);
                WriteLiteral(" </td>\r\n            <td>");
                EndContext();
                BeginContext(1129, 17, false);
#line 46 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.PriceHookah);

#line default
#line hidden
                EndContext();
                BeginContext(1146, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1170, 11, false);
#line 47 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.Iamge);

#line default
#line hidden
                EndContext();
                BeginContext(1181, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1205, 15, false);
#line 48 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.CoordsLat);

#line default
#line hidden
                EndContext();
                BeginContext(1220, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1244, 15, false);
#line 49 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.CoordsLon);

#line default
#line hidden
                EndContext();
                BeginContext(1259, 25, true);
                WriteLiteral("</td>\r\n\r\n            <td>");
                EndContext();
                BeginContext(1285, 19, false);
#line 51 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.WorkTimeStart);

#line default
#line hidden
                EndContext();
                BeginContext(1304, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1328, 17, false);
#line 52 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.WorkTimeEnd);

#line default
#line hidden
                EndContext();
                BeginContext(1345, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1369, 16, false);
#line 53 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.FullAdress);

#line default
#line hidden
                EndContext();
                BeginContext(1385, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1409, 8, false);
#line 54 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.Vk);

#line default
#line hidden
                EndContext();
                BeginContext(1417, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1441, 15, false);
#line 55 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.Instagram);

#line default
#line hidden
                EndContext();
                BeginContext(1456, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1480, 8, false);
#line 56 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.Ok);

#line default
#line hidden
                EndContext();
                BeginContext(1488, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1512, 23, false);
#line 57 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.ComplimentsHookah);

#line default
#line hidden
                EndContext();
                BeginContext(1535, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1559, 27, false);
#line 58 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.ComplimentsAtmosphere);

#line default
#line hidden
                EndContext();
                BeginContext(1586, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1610, 24, false);
#line 59 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.ComplimentsKitchen);

#line default
#line hidden
                EndContext();
                BeginContext(1634, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1658, 14, false);
#line 60 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.MenuUrl1);

#line default
#line hidden
                EndContext();
                BeginContext(1672, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1696, 14, false);
#line 61 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.MenuUrl2);

#line default
#line hidden
                EndContext();
                BeginContext(1710, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1734, 19, false);
#line 62 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.ReviewsRating);

#line default
#line hidden
                EndContext();
                BeginContext(1753, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1777, 18, false);
#line 63 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
           Write(hooka.ReviewsCount);

#line default
#line hidden
                EndContext();
                BeginContext(1795, 39, true);
                WriteLiteral("</td>\r\n           \r\n\r\n\r\n        </tr>\r\n");
                EndContext();
#line 68 "C:\Users\leade\source\repos\WebApiForHookahv1.0\WebApiForHookahv1.0\Views\Home\Index.cshtml"
        }

#line default
#line hidden
                BeginContext(1845, 14, true);
                WriteLiteral("    </table>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1866, 11, true);
            WriteLiteral("\r\n\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApiForHookahv1._0.Models.Hooka>> Html { get; private set; }
    }
}
#pragma warning restore 1591
