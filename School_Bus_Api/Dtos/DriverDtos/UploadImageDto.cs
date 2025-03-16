using Microsoft.Extensions.FileProviders;

namespace School_Bus_Api.Dtos.DriverDtos
{
    public class UploadImageDto
    {
        public IFormFile File { set; get; }
        public int DriverId { set; get; }
    }
}
