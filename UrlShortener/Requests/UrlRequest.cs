namespace UrlShortener.Requests;

public class UrlRequest
{
	// ReSharper disable once UnusedAutoPropertyAccessor.Global
	public required string MaskedUrl { get; set; }
	// ReSharper disable once UnusedAutoPropertyAccessor.Global
	public string? UserId { get; set; }
	// ReSharper disable once UnusedAutoPropertyAccessor.Global
	public string? ShortCutName { get; set; }
}