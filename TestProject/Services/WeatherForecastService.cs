using TestProject.IService;
using TestProject.Model;

namespace TestProject.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {

        private static readonly string[] Summaries = new[]
        {
                    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public bool DeleteData(int Index)
        {

            var s = Summaries.ToList();
            s.RemoveAt(Index);
            return true;
        }

        public IEnumerable<WeatherForecast> get(int p1 , int p2)
        {
            return Enumerable.Range(p1, p2).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
                .ToArray();
        }

    }

}
