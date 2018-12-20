using AngleSharp.Dom.Html;

namespace WebMovieSearch1.Afisha
{
    public interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
