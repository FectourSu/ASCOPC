using AngleSharp.Html.Dom;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Interfaces.Parser;
using System;
using System.Text.RegularExpressions;

namespace ASCOPC.Infrastructure.Parser.Citilink
{
    public class CitilinkParserItem : IParser<ComponentsDTO>
    {
        public ComponentsDTO Parse(IHtmlDocument document)
        {
            var item = new ComponentsDTO();

            var name = ParseTextContent(document,
                "div.ProductCardLayout__product-description div h1").Trim();
            item.Name = Regex.Replace(name, @"[а-яА-ЯёЁ+^()]", "").TrimStart();

            var code = ParseTextContent(document,
                "div.ProductCardLayout__product-description " +
                "div div.ProductHeader__info div.ProductHeader__product-id").Trim();
            item.Code = int.Parse(Regex
                .Replace(code, @"[[а-яА-ЯёЁ:\s]", ""));

            item.Manufacturer = ParseTextContent(document, 
                "div.ProductCardLayout__breadcrumbs div div div:nth-child(4) a span").Trim();

            item.Description = ParseTextContent(document,
                "div.AboutTab__description-text p:nth-child(1)");

            var rating = ParseTextContent(document,
                "span.IconWithCount__count").Trim();
            item.Rating = decimal.Parse(rating);

            item.Price = 0;
            item.InStock = false;
            var inStock = ParseTextContent(document,
                "h2.ProductHeader__not-available-header");

            if (String.IsNullOrWhiteSpace(inStock))
            {
                item.InStock = true;
                
                var price = ParseTextContent(document,
                    "span.ProductHeader__price-default_current-price").Trim();
                item.Price = decimal.Parse(string
                    .Join(".", price
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)));
            }

            item.UrlImage = ParseAttribute(document,
                "#item-1 img", "src");

            item.Type = ParseTextContent(document,
                "div.ProductCardLayout__breadcrumbs div div div:nth-child(3) a span").Trim();

            item.Specification = ParseProperties(document);

            return item;
        }
        
        public string ParseAttribute(IHtmlDocument document, string selector, string attribure) =>
            document.QuerySelector(selector).GetAttribute(attribure);

        public string ParseTextContent(IHtmlDocument document, string selector)
        {
            try
            {
                return document.QuerySelector(selector).TextContent;
            }
            catch
            {
                return string.Empty; 
            }
        }


        public SpecificationsDTO[] ParseProperties(IHtmlDocument document)
        {
            var result = new List<SpecificationsDTO>();

            var elements = document.QuerySelector("div.Specifications").Children;

            foreach (var div in elements)
            {
                result.Add(new SpecificationsDTO
                {
                    SpecificationTitle = div.QuerySelector("div.Specifications__column_name")
                    .TextContent
                    .Trim(),
                    SpecificationValue = div.QuerySelector("div.Specifications__column_value")
                    .TextContent
                    .Trim()
                });
            }

            return result.ToArray();
        }

    }
}
