using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assign1.Models
{
    public partial class Cutomers
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "You must enter a cuustomer name.")]
        [StringLength(50)]
        [Display(Name = "Customer Full Name:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You must enter an address.")]
        [StringLength(50)]
        [Display(Name = "Address:")]
        public string Address { get; set; }
        [Required(ErrorMessage = "You must enter a city.")]
        [StringLength(50)]
        [Display(Name = "City:")]
        public string City { get; set; }
        [Required(ErrorMessage = "You must enter a postal code.")]
        [StringLength(8)]
        [Display(Name = "Postal Code:")]
        public string PostalCode { get; set; }
        [Display(Name = "Province")]
        public int ProvId { get; set; }
        [Display(Name = "Warrenty:")]
        public int WarrentyId { get; set; }
        [Display(Name = "Vehical Make:")]
        public int CarMakeId { get; set; }
        [Display(Name = "Vehical Model:")]
        public int CarModelId { get; set; }
        [Required(ErrorMessage = "You must enter the vehical Year.")]
        [StringLength(4)]
        [Display(Name = "Vehical Year:")]
        public string CarYear { get; set; }
        [Required(ErrorMessage = "You must enter a 17 Digit VIN")]
        [Column("V.I.N.")]
        [StringLength(17)]
        public string VIN { get; set; }

        [ForeignKey("CarMakeId")]
        [InverseProperty("Cutomers")]
        public virtual Cmake CarMake { get; set; }
        [ForeignKey("CarModelId")]
        [InverseProperty("Cutomers")]
        public virtual Cmodel CarModel { get; set; }
        [ForeignKey("ProvId")]
        [InverseProperty("Cutomers")]
        public virtual Province Prov { get; set; }
        [ForeignKey("WarrentyId")]
        [InverseProperty("Cutomers")]
        public virtual Warrenty Warrenty { get; set; }
    }
}
