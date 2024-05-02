using TestProject.Model;

namespace TestProject.IService
{
    public interface IWeatherForecastService
    {
        public IEnumerable<WeatherForecast> get(int p1, int p2);

        public bool DeleteData(int Index);
    }
}
