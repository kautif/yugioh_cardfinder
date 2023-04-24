using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace yugioh_cardfinder.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        public IActionResult Index()
        {
            string ygoJSON = getYGOData();
            return View((object)ygoJSON);
        }

        private string getYGOData()
        {
            var client = new HttpClient();
            string searchTerm = "dragon";
            var ygoURL = $"https://db.ygoprodeck.com/api/v7/cardinfo.php?fname={searchTerm}";
            var ygoResponse = client.GetStringAsync(ygoURL).Result;
            Console.WriteLine(ygoResponse);
            var ygoJSON = JsonObject.Parse(ygoResponse)["data"].ToString();
            return ygoJSON;
        }
    }
}
