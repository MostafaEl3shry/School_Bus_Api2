using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace School_Bus_Api.Model
{
    public class DriverModel
    {
        const string EgyptionPhoneNumper = @"^((\+|00)20|0)?1[0125]\d{8}$";

        [Key]
        public int Id { get; set; }

        [Required]
        //[Range(1,5,ErrorMessage = "Code Must Be between 1 and 5 Numbers")]
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

        public string? DriverImg { get; set; }

        [Required]
        //[Range(1, 5, ErrorMessage = "Code Must Be between 1 and 5 Numbers")]
        public int BusCode { get; set; }


        [ForeignKey("busModelId")]
        public int busModelId { get; set; }
        public BusModel busModel { get; set; }
    }
}
