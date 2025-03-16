using School_Bus_Api.Dtos.DriverDtos;
using School_Bus_Api.Model;

namespace School_Bus_Api.Repos.Driver_Repo
{
    public interface IDriverRepo
    {
        List<DriverShowDataDto> GetAllDrivers();
        DriverShowDataDto GetDriverById(int id);
        DriverAddDataDto AddDriver(DriverAddDataDto driverDto);
        DriverAddDataDto UpdateDriver(int id, DriverAddDataDto driverDto);
        bool DeleteDriver(int id);
        bool BusExists(int busCode);

        string UploadImage(int userId,IFormFile file);
    }


}
