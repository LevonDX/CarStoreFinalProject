using CarStore.Data.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Data
{
    internal interface ICarRepository
    {
        Task AddCarAsync(Car car);
        Task<Car> GetCarByIdAsync(Guid id);
        Task<List<Car>> GetCarsAsync();
        Task<Car> UpdateCarAsync(Car car);
    }
}
