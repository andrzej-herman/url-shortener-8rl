using UrlShortener.Requests;

namespace UrlShortener.RedirectServices;

public interface IUrlService
{
	Task<string> GetRealUrl(string token);
	Task<string> GenerateShortUrl(UrlRequest request);
}