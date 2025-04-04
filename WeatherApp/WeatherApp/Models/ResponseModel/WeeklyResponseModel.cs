    using System.Collections.Generic;
    using Newtonsoft.Json; 

namespace WeatherApp.Models.ResponseModel
{
        public class OneCallApiResponse
        {
            [JsonProperty("lat")] 
            public double Latitude { get; set; } 

            [JsonProperty("lon")]
            public double Longitude { get; set; }

            [JsonProperty("timezone")]
            public string Timezone { get; set; }

            [JsonProperty("daily")]
            public List<DailyForecast> Daily { get; set; } 

        }

        public class DailyForecast
        {
            [JsonProperty("dt")]
            public long DtUnixTimestamp { get; set; }

            [JsonProperty("temp")]
            public Temperature TemperatureInfo { get; set; }

            [JsonProperty("weather")]
            public List<WeatherInfo> WeatherConditions { get; set; }

            [JsonProperty("humidity")]
            public int Humidity { get; set; }

            [JsonProperty("pressure")]
            public int Pressure { get; set; }

            [JsonProperty("wind_speed")]
            public double WindSpeed { get; set; }

            [JsonProperty("summary")] 
            public string Summary { get; set; }
        }

        public class Temperature
        {
            [JsonProperty("min")]
            public double Min { get; set; } // en düşük sıcaklık

            [JsonProperty("max")]
            public double Max { get; set; } // en yüksek sıcaklık

            [JsonProperty("day")]
            public double Day { get; set; }
        }

        public class WeatherInfo
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("main")]
            public string Main { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; } 

            [JsonProperty("icon")]
            public string Icon { get; set; } 
        }

        public class WeeklyForecastDayViewModel
        {
            public string DayName { get; set; }
            public double TempMax { get; set; }
            public double TempMin { get; set; }
            public string Description { get; set; }
            public string Icon { get; set; }

            public string IconUrl => $"http://openweathermap.org/img/wn/{Icon}@2x.png";
        }
    }
