#pragma checksum "C:\Users\Dell\source\repos\Reporting\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "673b6551b46de80e6f5a4bec62dddecc2deb85af"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Dell\source\repos\Reporting\Views\_ViewImports.cshtml"
using Reporting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dell\source\repos\Reporting\Views\_ViewImports.cshtml"
using Reporting.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Dell\source\repos\Reporting\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"673b6551b46de80e6f5a4bec62dddecc2deb85af", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b0132849abef22a398d6e129ff70c87a8289fcc", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Reporting.ViewModels.FraudesViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap-datepicker/css/bootstrap-datepicker.standalone.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Facturation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Clientele", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("small-box-footer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Fraudes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap-datepicker/js/bootstrap-datepicker.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap-datepicker/locales/bootstrap-datepicker.fr.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap-datepicker/js/datepicker-init.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Dell\source\repos\Reporting\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Acueil";




#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Header", async() => {
                WriteLiteral("\r\n    <!-- Daterange picker -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "673b6551b46de80e6f5a4bec62dddecc2deb85af6912", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script type=\"text/javascript\" src=\"https://www.gstatic.com/charts/loader.js\"></script>\r\n");
            }
            );
            WriteLiteral(@"

<!--<partial name=""sidebar"" />

<!-- Content Wrapper. Contains page content -->
<div class=""cont"">
    <!-- Content Header (Page header) -->
    <div class=""content-header"">

    </div>
    <!-- /.content-header -->
    <!-- Main content -->
    <section class=""content"">
        <!--  <div class=""container-fluid"">
        <!-- Small boxes (Stat box) -->
        <div class=""row"">
            <div class=""col-lg-3 col-6"">
                <!-- small box -->
                <div class=""small-box bg-info"">
                    <div class=""inner"">
                        <h3>");
#nullable restore
#line 34 "C:\Users\Dell\source\repos\Reporting\Views\Home\Index.cshtml"
                       Write(ViewBag.totalFac);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n                        <p>Total des Factures</p>\r\n                    </div>\r\n                    <div class=\"icon\">\r\n                        <i class=\"ion ion-bag\"></i>\r\n                    </div>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "673b6551b46de80e6f5a4bec62dddecc2deb85af9327", async() => {
                WriteLiteral("\r\n                        Plus d\'informations <i class=\"fas fa-arrow-circle-right\"></i>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
            </div>
            <!-- ./col -->
            <div class=""col-lg-3 col-6"">
                <!-- small box -->
                <div class=""small-box bg-success"">
                    <div class=""inner"">
                        <h3>");
#nullable restore
#line 51 "C:\Users\Dell\source\repos\Reporting\Views\Home\Index.cshtml"
                       Write(ViewBag.totalMontant);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<sup style=""font-size: 20px""></sup></h3>

                        <p>Montant Total des Factures</p>
                    </div>
                    <div class=""icon"">
                        <i class=""ion ion-stats-bars""></i>
                    </div>
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "673b6551b46de80e6f5a4bec62dddecc2deb85af11669", async() => {
                WriteLiteral(" Plus d\'informations<i class=\"fas fa-arrow-circle-right\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
            </div>
            <!-- ./col -->
            <div class=""col-lg-3 col-6"">
                <!-- small box -->
                <div class=""small-box bg-warning"">
                    <div class=""inner"">
                        <h3>  ");
#nullable restore
#line 66 "C:\Users\Dell\source\repos\Reporting\Views\Home\Index.cshtml"
                         Write(ViewBag.totalFraudes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n                        <p> Total des Fraudes</p>\r\n                    </div>\r\n                    <div class=\"icon\">\r\n                        <i class=\"ion ion-person-add\"></i>\r\n                    </div>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "673b6551b46de80e6f5a4bec62dddecc2deb85af13932", async() => {
                WriteLiteral(" Plus d\'informations <i class=\"fas fa-arrow-circle-right\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
            </div>
            <!-- ./col -->
            <div class=""col-lg-3 col-6"">
                <!-- small box -->
                <div class=""small-box bg-danger"">
                    <div class=""inner"">
                        <h3>  ");
#nullable restore
#line 81 "C:\Users\Dell\source\repos\Reporting\Views\Home\Index.cshtml"
                         Write(ViewBag.totalMFraudes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n                        <p>Montant Total des Fraudes</p>\r\n                    </div>\r\n                    <div class=\"icon\">\r\n                        <i class=\"ion ion-pie-graph\"></i>\r\n                    </div>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "673b6551b46de80e6f5a4bec62dddecc2deb85af16202", async() => {
                WriteLiteral(" Plus d\'informations <i class=\"fas fa-arrow-circle-right\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
            </div>
            <!-- ./col -->
        </div>
        <!-- /.row -->
        <!-- Main row -->
        <div class=""row"">
            <!-- Left col -->
            <section class=""col-3 "">


                <div class=""card bg-gradient-secondary"" style=""width: 315px"">
                    <div class=""card-header border-0"">

                        <h3 class=""card-title"">
                            <i class=""far fa-calendar-alt""></i>
");
            WriteLiteral("                        </h3>\r\n");
            WriteLiteral(@"                        <div class=""card-tools"">

                            <button type=""button"" class=""btn btn-secondary btn-sm"" data-card-widget=""collapse"">
                                <i class=""fas fa-minus""></i>
                            </button>
                            <button type=""button"" class=""btn btn-secondary btn-sm"" data-card-widget=""remove"">
                                <i class=""fas fa-times""></i>
                            </button>
                        </div>
");
            WriteLiteral("                    </div>\r\n");
            WriteLiteral("                    <div class=\"card-body pt-0\">\r\n");
            WriteLiteral("                        <div id=\"datepicker2\"></div>\r\n                    </div>\r\n");
            WriteLiteral(@"                </div>


            </section>
            <section class=""col-9 "">
                <div id=""chart_divv"" style=""width:1000px; height: 370px;""></div>

            </section>
        </div>

    </section>
    <div class=""row"">
        <section class=""col-7"">
            <div class=""card"">
                <table id=""myTable"" class=""table-success display responsive nowrap"">
                    <thead>
                        <tr>
                            <th>
                                NUM_CLI
                            </th>
                            <th>
                                MNT_FAC
                            </th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 151 "C:\Users\Dell\source\repos\Reporting\Views\Home\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 155 "C:\Users\Dell\source\repos\Reporting\Views\Home\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.NUM_CLI));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 158 "C:\Users\Dell\source\repos\Reporting\Views\Home\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.MNT_FAC));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 161 "C:\Users\Dell\source\repos\Reporting\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </section>
        <section class=""col-5 "">
            <div id=""chart_div"" style=""width:480px; height:520px;""></div>

        </section>

    </div>
   

</div>



    <link rel=""stylesheet"" href=""https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"">

    <script src=""https://code.jquery.com/ui/1.12.1/jquery-ui.js""></script>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "673b6551b46de80e6f5a4bec62dddecc2deb85af21659", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "673b6551b46de80e6f5a4bec62dddecc2deb85af22703", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "673b6551b46de80e6f5a4bec62dddecc2deb85af23751", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    <script>

        $(document).ready(function () {


            $('#myTable').DataTable({
                ""language"": {
                    ""url"": ""//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/French.json"",
                    ""responsive"": true,
                }
            });
        });
        google.charts.load('current', {
            packages: ['corechart', 'bar']
        });
        google.charts.setOnLoadCallback(LoadData);

        function LoadData() {
            $.ajax({

                url: '/Home/FactureChart/',
                dataType: ""json"",
                type: ""GET"",
                error: function (xhr, status, error) {
                    var err = eval(""("" + xhr.responseText + "")"");
                    toastr.error(err.message);
                },
                success: function (data) {
                    FactureChart(data);
                    return false;
                }
            });
            return false;
        }

       ");
            WriteLiteral(@" function FactureChart(data) {
            var dataArray = [
                ['dop', 'mnT_FACT_TOTAL']
            ];
            $.each(data, function (i, item) {
                dataArray.push([item.dop, item.mnT_FACT_TOTAL]);
            });
            var data = google.visualization.arrayToDataTable(dataArray);
            var options = {
                title: 'Montant totale pour chaque Dop pour Les Factures',
                chartArea: {
                    width: '50%'
                },
                colors: ['#b0120a', '#7b1fa2'],
                hAxis: {
                    title: 'DOP',
                    minValue: 0
                },
                vAxis: {
                    title: 'Montant Total'
                }
            };
            var chart = new google.visualization.PieChart(document.getElementById('chart_div'));

            chart.draw(data, options);
            return false;
        }

        google.charts.load('current', {
            packages");
            WriteLiteral(@": ['corechart', 'bar']
        });
        google.charts.setOnLoadCallback(LoadDataa);

        function LoadDataa() {
            $.ajax({

                url: '/Home/FraudesChart/',
                dataType: ""json"",
                type: ""GET"",
                error: function (xhr, status, error) {
                    var err = eval(""("" + xhr.responseText + "")"");
                    toastr.error(err.message);
                },
                success: function (data) {
                    FraudesChart(data);
                    return false;
                }
            });
            return false;
        }

        function FraudesChart(data) {
            var dataArray = [
                ['dop', 'mnT_FACT_TOTAL']
            ];
            $.each(data, function (i, item) {
                dataArray.push([item.dop, item.mnT_FACT_TOTAL]);
            });
            var data = google.visualization.arrayToDataTable(dataArray);
            var options = {
                t");
            WriteLiteral(@"itle: 'Montants Totals pour chaque Dop pour les Fraudes ',
                chartArea: {
                    width: '50%',
                },
                colors: ['#ffff00'],
                hAxis: {
                    title: 'DOP',
                    minValue: 0,
                },
                vAxis: {
                    title: 'Montant'
                }
            };
            var chart = new google.visualization.ColumnChart(document.getElementById('chart_divv'));

            chart.draw(data, options);
            return false;
        }

        $(function () {
            $(""#datepicker2"").datepicker({
                format: ""dd/MM/yyyy"",
                startView: 2,
                language: ""fr""
            })
        });
    </script>
















    <style>
        .cont{
            margin-left: 50px;
           
        }
        .content {
          
            margin-right: 50px;
        }
    </style>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Reporting.ViewModels.FraudesViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591