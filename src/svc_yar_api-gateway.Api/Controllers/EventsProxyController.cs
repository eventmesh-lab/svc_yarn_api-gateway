using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace svc_yar_api_gateway.Api.Controllers
{
    [ApiController]
    [Route("api/eventos")]
    public class EventsProxyController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EventsProxyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Public endpoint (GET /api/eventos/publicados)
        [HttpGet("publicados")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPublicEvents()
        {
            var client = _httpClientFactory.CreateClient("eventos");

            // Forward the incoming query string
            var path = "/api/eventos/publicados" + (Request.QueryString.HasValue ? Request.QueryString.Value : string.Empty);

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, path);

            // Forward correlation id if present
            if (Request.Headers.TryGetValue("X-Correlation-ID", out var correlation))
            {
                requestMessage.Headers.Add("X-Correlation-ID", correlation.ToString());
            }

            var response = await client.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();

            return new ContentResult
            {
                Content = content,
                StatusCode = (int)response.StatusCode,
                ContentType = "application/json"
            };
        }
    }
}
