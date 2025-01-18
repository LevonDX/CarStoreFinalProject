using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Data.Data.Entities
{
    public class CarMake : BaseEntity
    {
        public CarMake()
        {
            CarModels = new List<CarModel>();
        }
        public required string Name { get; set; }

        public virtual ICollection<CarModel> CarModels { get; set; }
    }
}
