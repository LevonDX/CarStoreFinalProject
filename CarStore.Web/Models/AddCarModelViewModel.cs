using CarStore.Data.Data.Entities;
using System.ComponentModel;

namespace CarStore.Web.Models
{
    public class AddCarModelViewModel
    {
        [DisplayName("Model name")]
        public required string ModelName { get; set; }

        [DisplayName("Select maker")]
        public Guid CarMakeId { get; set; }

        public List<CarMake> CarMakes { get; set; } = new List<CarMake>();
    }
}