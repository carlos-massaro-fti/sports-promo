using SportsPromo.Comum.Dados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public static MvcHtmlString LinkDeOrdenacao<T>(this HtmlHelper htmlHelper, PaginadoOrdenadoAbstrato<T> catalogo, Expression<Func<T, object>> expression)
        {
            System.Reflection.MemberInfo memberInfo;

            if (expression.Body is System.Linq.Expressions.UnaryExpression)
            {
                var expressionBody = (System.Linq.Expressions.UnaryExpression)expression.Body;
                var expressionOperand = (System.Linq.Expressions.MemberExpression)expressionBody.Operand;
                memberInfo = expressionOperand.Member;

            }
            else
            {
                var expressionBody = (System.Linq.Expressions.MemberExpression)expression.Body;
                memberInfo = expressionBody.Member;
            }
            var atributo = memberInfo.Name;
            var atributoNome = atributo;

            if (memberInfo.CustomAttributes.Any(e => e.AttributeType == typeof(DisplayAttribute)))
            {
                var displayAttr = (DisplayAttribute)memberInfo.GetCustomAttributes(true).First(e => e.GetType() == typeof(System.ComponentModel.DataAnnotations.DisplayAttribute));
                atributoNome = displayAttr.Name;
            }


            var helper = new UrlHelper(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection);
            var builder = new StringBuilder();
            builder.Append("<a href=\"");

            builder.Append(helper.Action("Index", new { page = catalogo.PaginaAtual, sort = atributo, direction = catalogo.OrdemNome == atributo ? (catalogo.OrdemDirecao == 0 ? 1 : 0) : 0 }));
            builder.Append("\">");
            builder.Append(atributoNome);
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
