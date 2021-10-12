using System.ComponentModel.DataAnnotations;

namespace WirsolutExercise.Core.DTOs
{
    public class ClientsUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "* The first name field must be completed")]
        [MaxLength(50, ErrorMessage = "You must enter 50 characters maximum")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "* The last name field must be completed")]
        [MaxLength(50, ErrorMessage = "You must enter 50 characters maximum")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "* The DNI field must be completed")]
        public int DNI { get; set; }

        [Required(ErrorMessage = "* The cuit field must be completed")]
        [MaxLength(13, ErrorMessage = "Please enter a valid CUIT")]
        public string CUIT { get; set; }

        [MaxLength(50, ErrorMessage = "You must enter 50 characters maxmimum")]
        public string Address { get; set; }

        [MaxLength(50, ErrorMessage = "You must enter 50 characters maxmimum")]
        public string Location { get; set; }
    }
}

