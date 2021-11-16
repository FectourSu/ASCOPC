using AngleSharp.Html.Parser;
using ASOPC.Application.Interfaces.Parser;

namespace ASCOPC.Infrastructure.Parser
{
    public class ParserWorker<T>
        where T : class
    {
        private readonly IParser<T> _parser;

        private HtmlLoader loader;

        private string uri;

        public string Uri
        {
            get => uri;
            set {
                uri = value;
                loader = new HtmlLoader(uri);
            }
        }

        public event Action<object, T> OnCompleted;
        public event Action<object> OnStopped;

        public ParserWorker(IParser<T> parser)
            : this(parser, string.Empty)
        {

        }

        public ParserWorker(IParser<T> parser, string uri)
        {
            this._parser = parser;
            this.uri = uri;
        }
        
        public bool IsActive { get; private set; }

        public async Task Start()
        {
            IsActive = true;

            await Worker();
        }

        public void Abort()
        {
            IsActive = false;
        }

        private async Task Worker()
        {
            if (!IsActive)
            {
                OnStopped?.Invoke(this);
                return;
            }

            var source = await loader.GetSource();

            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException($"Is null {nameof(source)} by {uri}");

            var domParser = new HtmlParser();

            var document = await domParser.ParseDocumentAsync(source);

            var result = _parser.Parse(document);

            OnCompleted?.Invoke(this, result);
            IsActive = false;
        }
    }
}
