using Microsoft.EntityFrameworkCore;
using UrlShortener.Database;
using UrlShortener.RedirectServices;

var builder = WebApplication.CreateBuilder(args);
const string corsOrigins = "cors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsOrigins,
        corsPolicyBuilder =>
        {
            corsPolicyBuilder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUrlService, UrlService>();
builder.Services.AddDbContext<UrlContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Webio"),
        assembly => assembly.MigrationsAssembly(typeof(UrlContext).Assembly.FullName));
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors(corsOrigins);
app.MapControllers();
app.Run();

//https://sklep.lkslodz.pl/strona-glowna/43-87-koszulka-lks-rodowici-lodzianie.html#/