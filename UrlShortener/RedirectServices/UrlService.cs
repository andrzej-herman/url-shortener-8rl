using Microsoft.EntityFrameworkCore;
using UrlShortener.Database;
using UrlShortener.Database.Entities;
using UrlShortener.Requests;

namespace UrlShortener.RedirectServices;

public class UrlService : IUrlService
{
	private readonly UrlContext _context;
	public UrlService(UrlContext context)
	{
		_context = context;
	}
	
	public async Task<string> GetRealUrl(string token)
	{
		var db = await _context.UrlDatas!.FirstOrDefaultAsync(x => x.Token == token);
		return db != null ? db.MaskedUrl : "https://url.aherman.pl/notfound";
	}

	public async Task<string> GenerateShortUrl(UrlRequest request)
	{
		var db = await _context.Tokens!.OrderBy(x => x.Id).Where(x => x.IsAvailable).FirstOrDefaultAsync();
		if (db == null) return "brak wolnych adresów";
		var token = db.Value;
		db.IsAvailable = false;
		var urlData = new UrlData
		{
			ShortcutName = request.ShortCutName,
			Token = token,
			MaskedUrl = request.MaskedUrl,
			UserId = request.UserId ?? "anonymous"
		};
		
		await _context.UrlDatas!.AddAsync(urlData);
		await _context.SaveChangesAsync();
		return $"https://8rl.pl/{token}";
	}
}
