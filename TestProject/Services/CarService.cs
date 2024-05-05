using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestProject.DbConnection;
using TestProject.DTO;
using TestProject.IService;
using TestProject.Model;

namespace TestProject.Services
{
    public class CarService : ICarServic
    {
        private readonly ApplicationDbContext _dbContext;
        public CarService(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddCar(AddCarsDTO car)
        {
            // Auto Mapper
            var newCar = new Cars()
            {
                Id = Guid.NewGuid(),
                description = car.description,
                Model = car.Model,
                name = car.name
            };
            await _dbContext.Cars.AddAsync(newCar);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCar(Guid id)
        {
           var car = await _dbContext.Cars.FindAsync(id);
            if (car != null)
            {
                _dbContext.Cars.Remove(car);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<CarsResponseDto>> GetAll()
        {
            List<CarsResponseDto> dtoList = new List<CarsResponseDto>();
         
            var carList = await _dbContext.Cars.ToListAsync();
           
            foreach(var car in carList)
            {
                var dtoObj = new CarsResponseDto()
                {
                    name = car.name,
                    description = car.description,
                    Model = car.Model
                };

                dtoList.Add(dtoObj);
            }
            return dtoList;
        }

        public async Task<bool> UpdateCar(UpdateCarDTO car)
        {
            try
            {
                // Get Car
                var DbCar = await _dbContext.Cars.FindAsync(car.Id);

                if (DbCar == null)
                {
                    return false;
                }

                DbCar.name = car.name;
                DbCar.description = car.description;
                _dbContext.Cars.Update(DbCar);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
