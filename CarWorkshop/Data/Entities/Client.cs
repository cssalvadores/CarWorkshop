using System.ComponentModel.DataAnnotations;

namespace CarWorkshop.Data.Entities
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The field {0} can contain {1} characters length.")]
        public string Name { get; set; }
        
        [MaxLength(15, ErrorMessage = "The field {0} can contain {1} characters length.")]
        [Display(Name = "Telephone")]
        public string Telephone { get; set; }        
       
        [MaxLength(100, ErrorMessage = "The field {0} can contain {1} characters length.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

    }
}
