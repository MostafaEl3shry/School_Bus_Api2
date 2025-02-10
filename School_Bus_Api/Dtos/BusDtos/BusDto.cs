using School_Bus_Api.Dtos.DriverDtos;
using School_Bus_Api.Model;
using System.ComponentModel.DataAnnotations;

namespace School_Bus_Api.Dtos.BusDtos
{
    public class BusDto
    {
        [Required]
        //[Range(1, 5, ErrorMessage = "Code Must Be 5 Numbers")]
        public int BusCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Place { get; set; }
    }
}
