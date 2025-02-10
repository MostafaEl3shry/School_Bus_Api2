using System.ComponentModel.DataAnnotations;

namespace School_Bus_Api.Dtos.RegistrationDtos
{
    public class ForgetPasswordDto
    {
        const string StrongPassword = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,16}$";


        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Will Match This (example@gmail.com)")]
        public string studentEmail { get; set; }

        [Required]
        [RegularExpression(StrongPassword, ErrorMessage = "Enter Strong Password")]
        [DataType(DataType.Password, ErrorMessage = "Not Correct Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "please confirm your password")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }
    }
}
