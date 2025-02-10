using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using School_Bus_Api.Dtos.BusDtos;

namespace School_Bus_Api.Dtos.DriverDtos
{
    public class DriverAddDataDto
    {
        const string EgyptionPhoneNumper = @"^((\+|00)20|0)?1[0125]\d{8}$";

        [Required]
        //[Range(1, 5, ErrorMessage = "Code Must Be 5 Numbers")]
        public int DriverCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string DriverName { get; set; }

        [Required]
        [RegularExpression(EgyptionPhoneNumper, ErrorMessage = "Not Match Egyption Numbers Pattern")]
        [StringLength(11, ErrorMessage = "Phone number will 11 numbers")]
        public string DriverPhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string DriverAddress { get; set; }

        [Required]
        [MaxLength(14)]
        public string DriverID { get; set; }

        [Required]
        //[Range(1, 5, ErrorMessage = "Code Must Be 5 Numbers")]
        public int BusCode { get; set; }
    }
}
