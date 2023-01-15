using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace MvcWebUI.Areas.Admin.ViewComponents.Widgets
{
    public class WeatherTodayWidget : ViewComponent
    {
        string apiKey = "9503c33914553190ebe49eb7f899de09";
        string api = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&units=metric&appid=";
        public IViewComponentResult Invoke()
        {
            string connection = api + apiKey;
            XDocument document = XDocument.Load(connection);
            ViewBag.Temperature = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
