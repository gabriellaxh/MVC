using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Firstname is too long!")]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Lastname is too long!")]
        public string Lastname { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Phone Number is too long!")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Second Phone Number is too long!")]
        [Display(Name = "Second Phone Number")]
        public string SecondPhoneNumber { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Address is too long!")]
        public string Address { get; set; }
    }
}