using SportsPromo.Comum.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace SportsPromo.Comum.Html
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString LinkDeOrdenacao<T>(this HtmlHelper htmlHelper, PaginadoOrdenadoAbstrato<T> catalogo, string atributo)
        {
            var helper = new UrlHelper(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection);
            var builder = new StringBuilder();
            builder.Append("<a href=\"");
            builder.Append(helper.Action("Index", new { page = catalogo.PaginaAtual, sort = atributo, direction = catalogo.OrdemNome == atributo ? (catalogo.OrdemDirecao == 0 ? 1 : 0) : 0 }));
            builder.Append("\">");
            builder.Append(atributo);
            if (catalogo.OrdemNome == atributo)
            {
                builder.Append("<sub>");
                if (catalogo.OrdemDirecao == 0)
                {
                    builder.Append("ASC");
                }
                else
                {
                    builder.Append("DESC");
                }
                builder.Append("</sub>");
            }

            builder.Append("</a>");



            var result = new MvcHtmlString(builder.ToString());

            return result;
        }
    }
}
