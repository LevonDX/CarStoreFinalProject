using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Data.Data.Entities
{
    public class CarModel : BaseEntity
    {
        public CarModel()
        {
            Cars = new List<Car>();
        }

        public required string Name { get; set; }

        [Required]
        [ForeignKey("CarMake")]
        public Guid CarMakeId { get; set; }
        public virtual CarMake CarMake { get; set; } = null!;

        public virtual List<Car> Cars { get; set; }
    }
}