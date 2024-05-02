using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestProject.DbConnection;
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
        public async Task<bool> AddCar(Cars car)
        {
            await _dbContext.Cars.AddAsync(car);
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

        public async Task<List<Cars>> GetAll()
        {
            return await _dbContext.Cars.ToListAsync();
        }

        public async Task<bool> UpdateCar(Cars car)
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
