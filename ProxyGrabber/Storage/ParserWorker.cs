using System;
using AngleSharp.Html.Parser;
using ProxyGrabber.Models.Interfaces;

namespace ProxyGrabber.Storage {
    public class ParserWorker<T> where T : class {
        IParser<T> parser;
        IParserSettings parserSettings;
        HtmlLoader loader;
        bool isActive;

        #region Properties
        public IParser<T> Parser {
            get { return parser; }
            set { parser = value; }
        }

        public IParserSettings ParserSettings {
            get {
                return parserSettings;
            }

            set {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }

        public bool IsActive { get { return isActive; } }
        #endregion 

        public event Action<object, T> OnNewData;
        public event Action<object> OnComplete;

        public ParserWorker(IParser<T> parser) {
            this.Parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser) {
            this.ParserSettings = parserSettings;
        }

        public void Start() {
            isActive = true;
            Worker();
        }

        public void Abort() {
            isActive = false;
        }

        public async void Worker() {
            for(int i = ParserSettings.FirstPage; i <= ParserSettings.LastPage;i++) {
                if (!isActive) {OnComplete?.Invoke(this); return; }

                var source = await loader.GetSourceByPageIdAsync(i);
                var domParser = new HtmlParser();

                var document = await domParser.ParseDocumentAsync(source);

                var result = parser.Parse(document);
                OnNewData?.Invoke(this, result);
            }

            OnComplete?.Invoke(this);
            isActive = false;
        }
    }
}