using ASCOPC.Infrastructure.Parser;
using ASCOPC.Infrastructure.Parser.Citilink;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Interfaces.Parser;
using Microsoft.Extensions.Logging;

namespace ASCOPC.Infrastructure.Services
{
    public class ParserService
    {
        private readonly ILogger<ParserService> _logger;

        public ParserService(ILogger<ParserService> logger)
        {
            _logger = logger;
        }

        public async Task<ComponentsDTO> ParseItem(IParserSettings settings, string type)
        {
            ComponentsDTO item = null;

            try
            {
                /// Вариант 1: forreach in ParseProductLink(settings) -> ParseProductItem
                item = await ParseProductItem($"{settings.Url}");
                item.Type = type;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} at the {settings.BaseUrl}");
            }

            return item;
        }

        Dictionary<string, string> dict = new()
        {
            { "Motherboard", "materinskie-platy" },
            { "CPU", "processory" }
        };

        /// Вариант 2: private -> public и вызов на Cantroller
        public async Task<IEnumerable<string>> ParseProductLink(IParserSettings settings)
        {
            var nav = settings.Navigate;

            if (dict.Keys.Contains(settings.Navigate))
                nav = dict[settings.Navigate];

            var productsLink = new List<string>();

            var parser = new ParserWorker<string[]>(new CitilinkParserLink());

            for (int i = settings.StartPoint; i < settings.EndPoint; i++)
            {
                parser.Uri = $"{settings.BaseUrl}/{nav}?{settings.Prefix}={i}";
            }

            return productsLink;
        }

        private async Task<ComponentsDTO?> ParseProductItem(string url)
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
    }
}
