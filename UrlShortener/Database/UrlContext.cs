using Microsoft.EntityFrameworkCore;
using UrlShortener.Database.Entities;

namespace UrlShortener.Database;

public class UrlContext : DbContext
{
	public UrlContext() {}
	public UrlContext(DbContextOptions<UrlContext> options) : base(options) {}
	public DbSet<UrlData>? UrlDatas { get; set; }
	public DbSet<TokenItem>? Tokens { get; set; }
	
	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<UrlData>()
			.HasIndex(u => u.Token)
			.IsUnique();
	}
}