using CarStore.Data.Data.Entities;
using CarStore.Web.Data;
using CarStore.Web.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly ICarSendMailService _carSendMailService;

        public CarController(IWebHostEnvironment webHostEnvironment, ICarSendMailService carSendMailService,
            ApplicationDbContext dbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = dbContext;
            _carSendMailService = carSendMailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UploadImage()
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", "cars");

            List<string> images = Directory.EnumerateFiles(path)
                        .Select(file => $"/img/cars/{Path.GetFileName(file)}")  // Convert to URL path
                        .ToList();

            return View(images);
        }

        [HttpPost]
        public IActionResult UploadImage(IFormFile file)
        {
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "cars", file.FileName);

            using (FileStream fileStream = new FileStream(imagePath, FileMode.Create))
            {
                file.CopyTo(fileStream);

                //using MemoryStream memoryStream = new MemoryStream();
                //file.CopyTo(memoryStream);

                //Car car = _context.Cars.FirstOrDefault();

                //if (car != null)
                //{
                //    car.ImageBytes = memoryStream.ToArray();
                //    _context.SaveChanges();
                //}

                //car.ImageBytes = _context.Cars.FirstOrDefault().ImageBytes;
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SendMail()
        {
            await _carSendMailService.SendMailAsync("levon@sestive.com", "test", "hello");
            return View();
        }

    }
}