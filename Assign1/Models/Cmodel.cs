using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assign1.Models
{
    [Table("CModel")]
    public partial class Cmodel
    {
        public Cmodel()
        {
            Cutomers = new HashSet<Cutomers>();
        }

        [Key]
        public int CarModelId { get; set; }
        [Required(ErrorMessage = "You must enter a vehical model.")]
        [StringLength(50)]
        [Display(Name = "Vehical Model")]
        public string CarModel { get; set; }

        [InverseProperty("CarModel")]
        public virtual ICollection<Cutomers> Cutomers { get; set; }
    }
}
