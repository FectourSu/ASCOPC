using AngleSharp.Html.Dom;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Interfaces.Parser;
using System.Text.RegularExpressions;

namespace ASCOPC.Infrastructure.Parser.Citilink
{
    public class CitilinkParserItem : IParser<ComponentsDTO>
    {
        public ComponentsDTO Parse(IHtmlDocument document)
        {
            var item = new ComponentsDTO();

            //var price = ParseTextContent(document, "div.price ins.num");
            //item.Price = decimal.Parse(price);

            //var name = ParseAttribute(document, "div.product_details div.not_display span[itemprop=name]", "content");
            //item.Name = Regex.Replace(name, @"[А-я]+\S+\s", string.Empty);

            //item.Manufacturer = ParseAttribute(document, "div.product_details div.not_display span[itemprop=brand]", "content");
            //item.Desciption = ParseAttribute(document, "div.product_details div.not_display span[itemprop=description]", "content");

            item.Specification = ParseProperties(document);

            return item;
        }

        public string ParseAttribute(IHtmlDocument document, string selector, string attribure) =>
            document.QuerySelector(selector).GetAttribute(attribure);

        public string ParseTextContent(IHtmlDocument document, string selector) =>
            document.QuerySelector(selector).TextContent;

        public SpecificationsDTO[] ParseProperties(IHtmlDocument document)
        {
            var result = new List<SpecificationsDTO>();

            var elements = document.QuerySelector("div.Specifications").Children;

            var str = new (string replace, string replacement)[]
                {
                    //("Maximum amount of memory", "Maximum amount of RAM")
                };

            foreach (var div in elements)
            {
                result.Add(new SpecificationsDTO
                {
                    SpecificationTitle = div.QuerySelector("div.Specifications__column_name").TextContent,
                    SpecificationValue = div.QuerySelector("div.Specifications__column_value").TextContent
                });
            }

            return result.ToArray();
        }

    }
}
