using Microsoft.AspNetCore.Mvc;
using UrlShortener.RedirectServices;
using UrlShortener.Requests;

namespace UrlShortener.Controllers
{
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _service;

        public UrlController(IUrlService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("generate")]
        public async Task<ActionResult> CreateShortUrl(UrlRequest request)
        {
            var url = await _service.GenerateShortUrl(request);
            return Ok(url);
        }
        
        [HttpGet]
        [Route("{token}")]
        public async Task<RedirectResult> Get(string token)
        {
            var url = await _service.GetRealUrl(token);
            return Redirect(url);
        }
    }
}