using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assign1.Models
{
    public partial class Province
    {
        public Province()
        {
            Cutomers = new HashSet<Cutomers>();
        }

        public int ProvinceId { get; set; }
        [Required(ErrorMessage = "You must enter a province.")]
        [Column("Province")]
        [StringLength(10)]
        public string Province1 { get; set; }

        [InverseProperty("Prov")]
        public virtual ICollection<Cutomers> Cutomers { get; set; }
    }
}
