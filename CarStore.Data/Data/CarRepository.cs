using CarStore.Data.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Data.Data
{
    public class CarRepository : ICarRepository // abstract repository pattern
    {
        public Task AddCarAsync(Car car)
        {
            throw new NotImplementedException();
        }

        public Task<Car> GetCarByIdAsync(Guid id)
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
