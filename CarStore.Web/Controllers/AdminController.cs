using CarStore.Data.Data.Entities;
using CarStore.Services.Abstract;
using CarStore.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ICarMakeService _carMakeService;
        private readonly ICarModelService _carModelService;
        private readonly ICarService _carService;

        public AdminController(
            ICarMakeService carMakeService,
            ICarModelService carModelService,
            ICarService carService)
        {
            _carMakeService = carMakeService;
            _carModelService = carModelService;
            _carService = carService;
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

            return RedirectToAction("add-car-model");
        }

        [HttpGet]
        [Route("admin/add-car-model")]
        public async Task<IActionResult> AddCarModel()
        {
            List<CarMake> carMakes = await _carMakeService.GetCarMakesAsync();

            AddCarModelViewModel model = new AddCarModelViewModel()
            {
                ModelName = "",
                CarMakes = carMakes
            };

            return View(model);
        }

        [HttpPost]
        [Route("admin/add-car-model")]
        public async Task<IActionResult> AddCarModel(AddCarModelViewModel model)
        {
            CarModel carModel = new CarModel
            {
                Id = Guid.NewGuid(),
                Name = model.ModelName,
                CarMakeId = model.CarMakeId
            };

            await _carModelService.AddCarModelAsync(carModel);

            return RedirectToAction("add-car");
        }

        [HttpGet]
        [Route("admin/add-car")]
        public async Task<IActionResult> AddCar()
        {
            AddCarViewModel addCarViewModel = new AddCarViewModel()
            {
                CarModels = await _carModelService.GetCarModelsAsync()
            };

            return View(addCarViewModel);
        }

        [HttpPost]
        [Route("admin/add-car")]
        public async Task<IActionResult> AddCar(AddCarViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            Car car = new Car
            {
                Id = Guid.NewGuid(),

                CarModelId = model.CarModelID,
                Color = model.Color,
                Price = model.Price,
                Year = model.Year
            };

            await _carService.AddCarAsync(car);

            return RedirectToAction("add-car");
        }
    }
}