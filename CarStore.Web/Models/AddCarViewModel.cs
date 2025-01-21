using CarStore.Data.Data.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarStore.Web.Models
{
    public class AddCarViewModel
    {
        [DisplayName("Car model")]
        public Guid CarModelID { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [DisplayName("Price")]
        public decimal? Price { get; set; }

        [DisplayName("Color")]
        public string? Color { get; set; }

        [DisplayName("Year")]
        public int? Year { get; set; }

        public List<CarModel> CarModels { get; set; } = new List<CarModel>();
    }
}
