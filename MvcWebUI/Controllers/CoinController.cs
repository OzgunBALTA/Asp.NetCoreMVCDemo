using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models.CoinModel;
using Newtonsoft.Json;

namespace MvcWebUI.Controllers
{
    public class CoinController : Controller
    {
        HttpClient httpClient = new HttpClient();
        public async Task<IActionResult> Index()
        {
            var response = await httpClient.GetAsync("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CoinModel>>(jsonString);
            return View(result);
        }
    }
}
