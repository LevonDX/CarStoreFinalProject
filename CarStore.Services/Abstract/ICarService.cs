using CarStore.Data.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Services.Abstract
{
    public interface ICarService
    {
        Task<List<Car>> GetCarsAsync();
        Task<Car> GetCarByIdAsync(Guid id);
        Task<Car> UpdateCarAsync(Car car);

        Task<CarModel> GetCarModel(Guid id);
    }
}
