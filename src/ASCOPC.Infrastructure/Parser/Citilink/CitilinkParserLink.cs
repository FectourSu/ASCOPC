using AngleSharp.Html.Dom;
using ASOPC.Application.Interfaces.Parser;

namespace ASCOPC.Infrastructure.Parser.Citilink
{
    public class CitilinkParserLink : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();

            var items = document.QuerySelectorAll("div.ProductCardHorizontal__header-block a");

            foreach (var item in items)
                list.Add(item.GetAttribute("href"));

            return list.ToArray();
        }
    }
}
