using CarStore.Data;
using CarStore.Services.Abstract;
using CarStore.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Services.Concrete
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;

        ICarStoreRepository<Car> _carStoreRepository;

        public CarService(CarStoreRepository<Car> carStoreRepository)
        {
            _carStoreRepository = carStoreRepository;
        }

        public void AddCars(Car car1, Car car2)
        {
            _carStoreRepository.Add(car1);
            _carStoreRepository.Add(car2);
            _carStoreRepository.SaveChanges();
        }

        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCarAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public Task<Car> GetCarByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CarModel> GetCarModel(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Car>> GetCarsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Car> UpdateCarAsync(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
