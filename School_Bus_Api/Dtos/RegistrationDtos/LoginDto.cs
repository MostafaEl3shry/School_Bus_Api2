using System.ComponentModel.DataAnnotations;

namespace School_Bus_Api.Dtos.RegistrationDtos
{
    public class LoginDto
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Will Match This (example@gmail.com)")]
        public string studentEmail { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Not Correct Password")]
        public string Password { get; set; }
    }
}
