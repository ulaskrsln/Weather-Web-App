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
                return Content("�ehir ad� giriniz!");

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

                    return Content($"�ehir: {city}<br>S�cakl�k: {temperature}�C<br>Durum: {description}");
                }
                else
                {
                    return Content("Hava durumu al�namad�.");
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

                // Veriyi d�nd�r
                return Json(new { temp, description, icon });
            }
        }


            [HttpGet]
        public ContentResult GetWeeklyWeather(string city)
        {
            var weeklyWeatherData = new[]
            {
        "Pazartesi: 18�C, A��k",
        "Sal�: 20�C, G�ne�li",
        "�ar�amba: 19�C, Bulutlu",
        "Per�embe: 17�C, Ya�murlu",
        "Cuma: 21�C, G�ne�li",
        "Cumartesi: 23�C, �ok g�ne�li",
        "Pazar: 22�C, Az bulutlu"
    };

            return Content(string.Join("\n", weeklyWeatherData), "text/plain");
        }


    }
}
