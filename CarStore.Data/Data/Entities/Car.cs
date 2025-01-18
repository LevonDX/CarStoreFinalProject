using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Data.Data.Entities
{
    public class Car : BaseEntity
    {
        [Required]
        [ForeignKey("CarModel")]
        public Guid CarModelId { get; set; }
        public virtual CarModel CarModel { get; set; } = null!;

        [Precision(18, 2)]
        public decimal? Price { get; set; }

        public string? Color { get; set; }

        public int? Year { get; set; }

        public List<string> Images { get; set; } = null!;
    }
}
