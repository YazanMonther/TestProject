using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject.IService;
using TestProject.Model;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarServic _carService;

        public CarController(ICarServic carService)
        {
            _carService = carService;
        }

        [HttpPost]
        [Route("AddCar")]
        public async Task<IActionResult> AddCar(Cars car)
        {
            var result =  await _carService.AddCar(car);
            if(result )
            return Ok(result);

            else
            {
                return BadRequest("Car hasnt Added ");
            }
        }


        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteCar(Guid Id)
        {
            var result = await _carService.DeleteCar(Id);
            if (result)
                return Ok(result);

            else
            {
                return BadRequest("Car hasnt Deleted ");
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _carService.GetAll();
            if (result != null)
                return Ok(result);

            else
            {
                return BadRequest("No Data ");
            }
        }

        [HttpPut]
        [Route("UpdateCar")]
        public async Task<IActionResult> UpdateCar(Cars car)
        {
            var result = await _carService.UpdateCar(car);
            if (result )
                return Ok(result);

            else
            {
                return BadRequest("No Data ");
            }
        }
    }
}
