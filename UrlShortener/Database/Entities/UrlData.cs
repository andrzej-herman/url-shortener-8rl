using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShortener.Database.Entities;

public class UrlData
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	
	public string? ShortcutName { get; set; }
	public required string Token { get; set; }
	
	public required string MaskedUrl { get; set; }

	public required string UserId { get; set; }
}