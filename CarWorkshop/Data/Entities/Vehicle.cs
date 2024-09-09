using System.ComponentModel.DataAnnotations;
using System;

namespace CarWorkshop.Data.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The field {0} can have a maximum of {1} characters.")]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The field {0} can have a maximum of {1} characters.")]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "The field {0} can have a maximum of {1} characters.")]
        [Display(Name = "License Plate")]
        public string LicensePlate { get; set; }

        [Required]
        [Display(Name = "Year")]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Mileage")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public int Mileage { get; set; }

        [Display(Name = "Last Inspection Date")]
        public DateTime? LastInspectionDate { get; set; }

        [Display(Name = "Under Repair")]
        public bool UnderRepair { get; set; }
    }
}
