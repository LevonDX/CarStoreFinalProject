using CarStore.Services.Abstract;
using CarStore.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Services.Concrete
{
    public class CarModelService : ICarModelService
    {
        private readonly ApplicationDbContext _context;

        public CarModelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCarModelAsync(CarModel carModel)
        {
            await _context.AddAsync(carModel);
            await _context.SaveChangesAsync();
        }

        public async Task<CarModel?> GetCarModelByIdAsync(Guid id)
        {
            return await _context.CarModels.FindAsync(id);
        }

        public async Task<List<CarModel>> GetCarModelsAsync()
        {
            return await _context.CarModels.ToListAsync();
        }

        public async Task UpdateCarModelAsync(CarModel carModel)
        {
            _context.CarModels.Update(carModel);
            await _context.SaveChangesAsync();
        }
    }
}
