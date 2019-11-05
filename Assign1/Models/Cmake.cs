using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assign1.Models
{
    [Table("CMake")]
    public partial class Cmake
    {
        public Cmake()
        {
            Cutomers = new HashSet<Cutomers>();
        }

        [Column("CMakeID")]
        public int CmakeId { get; set; }
        [Required(ErrorMessage = "You must enter a vehival make.")]
        [StringLength(50)]
        [Display(Name = "Vehical Make")]
        public string CarMake { get; set; }

        [InverseProperty("CarMake")]
        public virtual ICollection<Cutomers> Cutomers { get; set; }
    }
}
