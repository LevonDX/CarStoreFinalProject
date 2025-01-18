using CarStore.Data.Data.Entities;
using CarStore.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ICarMakeService _carMakeService;

        public AdminController(ICarMakeService carMakeService)
        {
            _carMakeService = carMakeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("admin/add-car-makes")]
        public IActionResult AddCarMake()
        {
            return View();
        }

        [HttpPost]
        [Route("admin/add-car-makes")]
        public async Task<IActionResult> AddCarMake(string name)
        {
            CarMake carMake = new CarMake
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            await _carMakeService.AddCarMakeAsync(carMake);

            return View();
        }
    }
}
