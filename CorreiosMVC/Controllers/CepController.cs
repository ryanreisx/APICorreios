using CorreiosMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CorreiosMVC.Controllers
{
    public class CepController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public CepController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetCepInfo(string cep)
        {
            try
            {
                var viaCepUrl = $"http://viacep.com.br/ws/{cep}/json/";

                var client = _httpClientFactory.CreateClient();
                var response = await client.GetFromJsonAsync<ViaCepModel>(viaCepUrl);

                return View(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
