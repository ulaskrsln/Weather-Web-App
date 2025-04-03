using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly string apiKey = "7492afa40ac6decc24d9235f3313fcbf"; 

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WeeklyForecast()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> GetWeather(string city)
        {
            if (string.IsNullOrEmpty(city))
                return Content("Þehir adý giriniz!");

            string apiUrl = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&units=metric&lang=tr&appid={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject weatherData = JObject.Parse(responseBody);

                    string temperature = weatherData["list"][0]["main"]["temp"].ToString();
                    string description = weatherData["list"][0]["weather"][0]["description"].ToString();

                    return Content($"Þehir: {city}<br>Sýcaklýk: {temperature}°C<br>Durum: {description}");
                }
                else
                {
                    return Content("Hava durumu alýnamadý.");
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherAbroad(string city)
        {
            var apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric&lang=tr";

            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(apiUrl);
                var weatherData = JsonConvert.DeserializeObject<dynamic>(response);

                var temp = weatherData.main.temp;
                var description = weatherData.weather[0].description;
                var icon = weatherData.weather[0].icon;

                // Veriyi döndür
                return Json(new { temp, description, icon });
            }
        }


            [HttpGet]
        public ContentResult GetWeeklyWeather(string city)
        {
            var weeklyWeatherData = new[]
            {
        "Pazartesi: 18°C, Açýk",
        "Salý: 20°C, Güneþli",
        "Çarþamba: 19°C, Bulutlu",
        "Perþembe: 17°C, Yaðmurlu",
        "Cuma: 21°C, Güneþli",
        "Cumartesi: 23°C, Çok güneþli",
        "Pazar: 22°C, Az bulutlu"
    };

            return Content(string.Join("\n", weeklyWeatherData), "text/plain");
        }


    }
}
