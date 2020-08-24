using AngleSharp.Html.Dom;

namespace ProxyGrabber.Models.Interfaces  {
    public interface IParser<T> where T : class {
        T Parse(IHtmlDocument document);
    }
}