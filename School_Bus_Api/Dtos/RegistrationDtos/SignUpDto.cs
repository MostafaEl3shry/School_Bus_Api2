using System.ComponentModel.DataAnnotations;

namespace School_Bus_Api.Dtos.RegistrationDtos
{
    public class SignUpDto
    {
        const string StrongPassword = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";

        const string EgyptionPhoneNumper = @"^((\+|00)20|0)?1[0125]\d{8}$";


        [Required]
        [MaxLength(15)]
        public string studentName { get; set; }

        [Required]
        [RegularExpression(EgyptionPhoneNumper, ErrorMessage = "Not Match Egyption Numbers Pattern")]
        [StringLength(11, ErrorMessage = "Phone number will 11 numbers")]
        public string studentPhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Will Match This (example@gmail.com)")]
        public string studentEmail { get; set; }

        [Required]
        [RegularExpression(StrongPassword, ErrorMessage = "Enter Strong Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "please confirm your password")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }

        [Required]
        [MaxLength(15)]
        public string parentName { get; set; }

        [Required]
        [RegularExpression(EgyptionPhoneNumper, ErrorMessage = "Not Match Egyption Numbers Pattern")]
        [StringLength(11, ErrorMessage = "Phone number will 11 numbers")]
        public string parentPhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
    }
}
