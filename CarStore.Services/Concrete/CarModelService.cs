using CarStore.Services.Abstract;
using CarStore.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CarModelService> _logger;

        public CarModelService(ApplicationDbContext context, ILogger<CarModelService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddCarModelAsync(CarModel carModel)
        {
            try
            {
                _logger.LogInformation("Adding car model {@CarModel}", carModel);

                await _context.AddAsync(carModel);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Car model {@CarModel} added", carModel);
            }
            catch
            {
                _logger.LogError("Failed to add car model {@CarModel}", carModel);
                throw;
            }
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
