using CarStore.Data.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Services.Abstract
{
    public interface ICarModelService
    {
        Task<List<CarModel>> GetCarModelsAsync();
        Task<CarModel?> GetCarModelByIdAsync(Guid id);
        Task UpdateCarModelAsync(CarModel carModel);

        Task AddCarModelAsync(CarModel carModel);
    }
}
