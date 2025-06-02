using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace sistema_gestao_decursos_online.Controllers
{
    public class ClimaController : Controller
    {
        private readonly HttpClient _httpClient;

        public ClimaController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index(string cidade = "Volta Redonda")
        {
            string apiKey = "2859321b5a68d290cc3eb0ad249b99a1";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={cidade}&appid={apiKey}&units=metric&lang=pt_br";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var clima = JsonSerializer.Deserialize<ClimaInfo>(json);
                return View(clima);
            }

            return View("Erro");
        }
    }
}
