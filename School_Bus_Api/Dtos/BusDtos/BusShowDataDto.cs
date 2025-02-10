using System.ComponentModel.DataAnnotations;

namespace School_Bus_Api.Dtos.BusDtos
{
    public class BusShowDataDto
    {
        public int Id { get; set; }

        [Required]
        //[Range(1, 5, ErrorMessage = "Code Must Be 5 Numbers")]
        public int BusCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Place { get; set; }
    }
}
