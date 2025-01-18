using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Services.Abstract
{
    public interface ICarMakeService
    {
        Task<List<CarMake>> GetCarMakesAsync();
        Task<CarMake> GetCarMakeByIdAsync(Guid id);
        Task<CarMake> UpdateCarMakeAsync(CarMake carMake);
        Task AddCarMakeAsync(CarMake carMake);
    }
}
