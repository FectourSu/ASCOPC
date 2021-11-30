using ASCOPC.Infrastructure.Parser;
using ASCOPC.Infrastructure.Parser.Citilink;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace ASCOPC.Infrastructure.Services
{
    public class ParserService : IParserService
    {
        private readonly ILogger<ParserService> _logger;
        public ParserService(ILogger<ParserService> logger)
        {
            _logger = logger;
        }

        public async Task<ComponentsDTO> ParseItem(string url)
        {
            ComponentsDTO item = null;

            try
            {
                item = await ParseProductItem(url);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} at the {url}");
            }

            return item;
        }
      
        private async Task<ComponentsDTO> ParseProductItem(string url)
        {
            var item = new ComponentsDTO();

            var parser = new ParserWorker<ComponentsDTO>(new CitilinkParserItem());

            parser.OnCompleted += (s, e) =>
            {
                _logger.LogInformation($"{e.Name} - successfully paired");
                item = e;
            };

            parser.Uri = url;

            await parser.Start();

            return item;
        }

        ///TODO: automatically parse components by pages
        //public async Task<IEnumerable<string>> ParseProductLink(IParserSettings settings)
        //{

        //    var nav = settings.Navigate;

        //    if (!specifications.Keys.Contains(settings.Navigate))
        //        throw new Exception($"There is {nav} no specification");

        //    nav = specifications[settings.Navigate];

        //    var products = new List<ComponentsDTO>();

        //    var href = new List<string>();

        //    var parser = new ParserWorker<string[]>(new CitilinkParserLink());

        //    parser.Start();
        //    parser.OnCompleted += (s, e) =>
        //    {
        //        href.AddRange(e);               
        //    };

        //    for (int i = 0; i < href.Count; i++)
        //    {
        //        parser.Uri = $"{settings.BaseUrl}/{nav}";
        //        products.Add(await ParseProductItem(parser.Uri));
        //    }

        //    if(settings.StartPoint != 0)
        //        for (int i = settings.StartPoint; i < settings.EndPoint; i++)
        //        {
        //            parser.Uri = $"{settings.BaseUrl}/{nav}?{settings.Prefix}={i}";
        //            products.Add(await ParseProductItem(parser.Uri));
        //        }

        //    return href;
        //}
    }
}
