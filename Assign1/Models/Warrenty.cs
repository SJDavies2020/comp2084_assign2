using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assign1.Models
{
    public partial class Warrenty
    {
        public Warrenty()
        {
            Cutomers = new HashSet<Cutomers>();
        }
        public int WarrentyId { get; set; }
        [StringLength(30)]
        public string WarrentyTerm { get; set; }
        [InverseProperty("Warrenty")]
        public virtual ICollection<Cutomers> Cutomers { get; set; }
    }
}
