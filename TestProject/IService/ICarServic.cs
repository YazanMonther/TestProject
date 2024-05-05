using TestProject.DTO;
using TestProject.Model;

namespace TestProject.IService
{
    public interface ICarServic
    {
        public  Task<bool> AddCar(AddCarsDTO car);
        public Task<bool> DeleteCar(Guid id);

        public Task<bool> UpdateCar(UpdateCarDTO car);
        public Task<List<CarsResponseDto>> GetAll();
    }
}
