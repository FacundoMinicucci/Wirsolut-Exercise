using System.ComponentModel.DataAnnotations;

namespace WirsolutExercise.Core.DTOs
{
    public class ClientsDTO
    {           
        public int Id { get; set; }

        [Required(ErrorMessage = "* The first name field must be completed")]
        [MaxLength(50, ErrorMessage = "You must enter 50 characters maximum")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "* The last name field must be completed")]
        [MaxLength(50, ErrorMessage = "You must enter 50 characters maximum")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "* The DNI field must be completed")]
        [Display(Name = "DNI")]
        public int DNI { get; set; }

        [Required(ErrorMessage = "* The CUIT field must be completed")]
        [MaxLength(13, ErrorMessage = "Please enter a valid CUIT")]
        [Display(Name = "CUIT")]
        public string CUIT { get; set; }

        [MaxLength(50, ErrorMessage = "You must enter 50 characters maxmimum")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [MaxLength(50, ErrorMessage = "You must enter 50 characters maxmimum")]
        [Display(Name = "Location")]
        public string Location { get; set; }
    }
}
