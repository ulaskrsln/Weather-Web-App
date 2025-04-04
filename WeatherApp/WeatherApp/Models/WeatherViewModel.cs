namespace WeatherApp.Models
{
    public class WeatherViewModel
    {
        public string City { get; set; }
        public string Temperature { get; set; }
        public string Description { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
    }
}
