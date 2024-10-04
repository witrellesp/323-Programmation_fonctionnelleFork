using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Running2;

namespace Running2
{
    public record WeatherData(Hourly hourly);

    public record Hourly(string[] time, float[] temperature_2m, float[] precipitation, float[] wind_speed_10m);

    public class Program
    {
        public static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            string url = "https://api.open-meteo.com/v1/forecast?latitude=46.3833&longitude=6.2348&hourly=temperature_2m,precipitation,wind_speed_10m";

            var response = await client.GetStringAsync(url);
            var weatherData = JsonConvert.DeserializeObject<WeatherData>(response);

            // Utilisez weatherData pour les étapes suivantes...

            //foreach (var time in weatherData.hourly.time)
            //{
            //    Console.WriteLine(time);
            //}
            var bestHours = GetBestRunningHours(weatherData.hourly);
            var avgTemperWind = CalculateAvg(weatherData.hourly);
            var hoursIdeals = CountIdealHours(weatherData.hourly);



            foreach (var hour in bestHours)
            {
                Console.WriteLine($"Time: {hour.Time}, Temperature: {hour.Temperature}°C, WindSpeed: {hour.WindSpeed} m/s");
            }

            Console.WriteLine(avgTemperWind);
            Console.WriteLine(hoursIdeals);


        }

        public static IEnumerable<(string Time, float Temperature, float WindSpeed)> GetBestRunningHours(Hourly hourly)
        {
            return hourly.time
                .Select((t, index) => new { Time = t, Temperature = hourly.temperature_2m[index], Precipitation = hourly.precipitation[index], WindSpeed = hourly.wind_speed_10m[index] })
                .Where(x => x.Temperature >= 18 && x.Temperature <= 22 && x.Precipitation == 0 && x.WindSpeed < 10)
                .Select(x => (x.Time, x.Temperature, x.WindSpeed));
        }
        public static (float AvgTemperature, float AvgWindSpeed) CalculateAvg(Hourly hourly)
        {

            var avgTemperature = hourly.temperature_2m.Average();
            var avgWinfSpeed = hourly.wind_speed_10m.Average();

            return (avgTemperature, avgWinfSpeed);

        }
        public static int CountIdealHours(Hourly hourly)
        {
            return hourly.time
            .Select((t, index) => new { Temperature = hourly.temperature_2m[index], Precipitation = hourly.precipitation[index], WindSpeed = hourly.wind_speed_10m[index] })
            .Aggregate(0, (count, hour) =>
            {
                if (hour.Temperature >= 15 && hour.Temperature <= 25 && hour.Precipitation == 0 && hour.WindSpeed < 15)
                    return count + 1;
                else
                    return count;
            });

        }
    }

}
