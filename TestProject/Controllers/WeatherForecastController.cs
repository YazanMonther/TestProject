using Microsoft.AspNetCore.Mvc;
using TestProject.IService;
using TestProject.Model;
using TestProject.Services;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastService _weatherForecast ;
        
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger , 
            IWeatherForecastService weatherForecast)
        {
            _logger = logger;
            _weatherForecast = weatherForecast;
        }

        [HttpGet]
        //Post To add data
        //Delete
        //Update
        [Route("GetWeatherData/{p1}/{p2}")]
        public IEnumerable<WeatherForecast> GetWeatheData(int p1 , int p2)
        {
            return _weatherForecast.get(p1,p2);
        }


        [HttpDelete]
        [Route("DeleteAt/{Index}")]
        public bool DeleteAT(int Index)
        {
            return _weatherForecast.DeleteData(Index);
        }
    }
}
