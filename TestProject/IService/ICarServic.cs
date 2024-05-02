using TestProject.Model;

namespace TestProject.IService
{
    public interface ICarServic
    {
        public  Task<bool> AddCar(Cars car);
        public Task<bool> DeleteCar(Guid id);

        public Task<bool> UpdateCar(Cars car);
        public Task<List<Cars>> GetAll();
    }
}
