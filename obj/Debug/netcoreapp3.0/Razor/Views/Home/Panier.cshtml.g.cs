#pragma checksum "/home/ay/codedotnet/Finalproject/Views/Home/Panier.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "719a745a439adc33417df42248ad028ca9580b43"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Panier), @"mvc.1.0.view", @"/Views/Home/Panier.cshtml")]
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
#line 1 "/home/ay/codedotnet/Finalproject/Views/_ViewImports.cshtml"
using Finalproject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/ay/codedotnet/Finalproject/Views/_ViewImports.cshtml"
using Finalproject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/ay/codedotnet/Finalproject/Views/Home/Panier.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"719a745a439adc33417df42248ad028ca9580b43", @"/Views/Home/Panier.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"194d7f97cfc7b799ab08fc3d847d1ba39547984e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Panier : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<System.Collections.Generic.List<Commande>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "/home/ay/codedotnet/Finalproject/Views/Home/Panier.cshtml"
  
    ViewData["Title"] = "Panier";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n\n\n\n\n<table style=\"\npadding-top: 1cm;\n\">  ");
#nullable restore
#line 15 "/home/ay/codedotnet/Finalproject/Views/Home/Panier.cshtml"
      int i=0;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "/home/ay/codedotnet/Finalproject/Views/Home/Panier.cshtml"
     while(i<@Model.Count)
    {
    int j=0;
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\n");
#nullable restore
#line 21 "/home/ay/codedotnet/Finalproject/Views/Home/Panier.cshtml"
         while((j<4 && i< @Model.Count) )
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"padding-left: 1.2cm;\n                       padding-top:1.2cm;\n            \">\n                ");
#nullable restore
#line 26 "/home/ay/codedotnet/Finalproject/Views/Home/Panier.cshtml"
           Write(Model[i].ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("     ||     ");
#nullable restore
#line 26 "/home/ay/codedotnet/Finalproject/Views/Home/Panier.cshtml"
                                   Write(Model[i].nomlivre);

#line default
#line hidden
#nullable disable
            WriteLiteral("  || <a");
            BeginWriteAttribute("href", " href=\"", 458, "\"", 503, 2);
            WriteAttributeValue("", 465, "supprimerlignecommande?ID=", 465, 26, true);
#nullable restore
#line 26 "/home/ay/codedotnet/Finalproject/Views/Home/Panier.cshtml"
WriteAttributeValue("", 491, Model[i].ID, 491, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Supprimer</a>  || \n                  \n                 <br>\n            </th>\n");
#nullable restore
#line 30 "/home/ay/codedotnet/Finalproject/Views/Home/Panier.cshtml"
            j++;
            i++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tr>\n");
#nullable restore
#line 34 "/home/ay/codedotnet/Finalproject/Views/Home/Panier.cshtml"
    
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<tr><th>Prxi: ");
#nullable restore
#line 38 "/home/ay/codedotnet/Finalproject/Views/Home/Panier.cshtml"
         Write(ViewBag.prixt);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
      </th></tr>
</table>


<div style=""background-color: DarkCyan; width: 92%;margin-left: 60px; border-radius: 40px;""  >
           <a href=""supprimertablecommande""> <p style=""text-align: center; font-size: 30px;"">Confirmer</p></a>
        </div>




<footer>
            <div style=""background-color:  #282828;
	background-position: center center;
	text-shadow: rgb(31, 23, 22) 20px 35px 50px;
	height: 140px;"">
              <p style=""color: white; padding-top: 0.3cm;"">User: ");
#nullable restore
#line 55 "/home/ay/codedotnet/Finalproject/Views/Home/Panier.cshtml"
                                                            Write(Context.Session.GetString("nom_user"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 55 "/home/ay/codedotnet/Finalproject/Views/Home/Panier.cshtml"
                                                                                                   Write(Context.Session.GetString("prenom_user"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n              <p style=\"color: white;\">Email: ");
#nullable restore
#line 56 "/home/ay/codedotnet/Finalproject/Views/Home/Panier.cshtml"
                                         Write(Context.Session.GetString("email_user"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n              <p style=\"color: white;\">Panier: <a href=\"Panier\" style=\"color:aqua\">Panier</a></p>\n              <p style=\"color: white;\">Deconnection: <a href=\"Logout\" style=\"color:aqua\">Deconnecxion</a></p>\n            </div>\n</footer>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<System.Collections.Generic.List<Commande>> Html { get; private set; }
    }
}
#pragma warning restore 1591
