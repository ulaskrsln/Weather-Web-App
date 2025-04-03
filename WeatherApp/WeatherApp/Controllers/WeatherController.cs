using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace YourProject.Controllers
{
    public class WeatherController : Controller
    {
        private readonly string apiKey = "7492afa40ac6decc24d9235f3313fcbf"; // OpenWeather API anahtarınızı buraya ekleyin
        private readonly string apiUrl = "https://api.openweathermap.org/data/2.5/onecall";

        // İstanbul için 7 günlük hava durumu
        [HttpGet]
        public async Task<IActionResult> WeeklyForecast()
        {
            var lat = 41.0082;  // İstanbul'un enlem koordinatı
            var lon = 28.9784;  // İstanbul'un boylam koordinatı
            var url = $"{apiUrl}?lat={lat}&lon={lon}&exclude=current,minutely,hourly,alerts&units=metric&lang=tr&appid={apiKey}";

            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);  // API'den veri alıyoruz
                var weatherData = JsonConvert.DeserializeObject<WeatherData>(response);

                var weeklyWeatherData = weatherData.Daily.Select(day =>
                    $"{GetDayName(day.Dt)}: {day.Temp.Day}°C, {day.Weather[0].Description}")
                    .ToArray();

                var weatherText = string.Join("\n", weeklyWeatherData);  // Haftalık verileri birleştiriyoruz
                return Content(weatherText, "text/plain");  // Text formatında döndürüyoruz
            }
        }

        // Unix timestamp'ten gün ismini alıyoruz
        private string GetDayName(long timestamp)
        {
            var dateTime = DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime;
            return dateTime.ToString("dddd");
        }

        // API'den alınan veriyi deseralize etmek için model
        public class WeatherData
        {
            public List<Daily> Daily { get; set; }
        }

        public class Daily
        {
            public long Dt { get; set; }
            public Temp Temp { get; set; }
            public List<Weather> Weather { get; set; }
        }

        public class Temp
        {
            public double Day { get; set; }
        }

        public class Weather
        {
            public string Description { get; set; }
        }
    }
}
