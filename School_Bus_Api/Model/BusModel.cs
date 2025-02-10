using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Bus_Api.Model
{
    public class BusModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        //[Range(1, 5, ErrorMessage = "Code Must Be 5 Numbers")]
        public int BusCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Place { get; set; }



        public DriverModel Driver { get; set; }
    }
}
