using Microsoft.EntityFrameworkCore;
using School_Bus_Api.Data;
using School_Bus_Api.Dtos.DriverDtos;
using School_Bus_Api.Model;

namespace School_Bus_Api.Repos.Driver_Repo
{
    public class DriverRepo : IDriverRepo
    {
        private readonly AppDbContext _context;

        public DriverRepo(AppDbContext context)
        {
            _context = context;
        }

        public List<DriverShowDataDto> GetAllDrivers()
        {
            var driver = _context.drivers.Select(d => new DriverShowDataDto
            {
                Id = d.Id,
                DriverCode = d.DriverCode,
                DriverName = d.DriverName,
                DriverPhoneNumber = d.DriverPhoneNumber,
                DriverAddress = d.DriverAddress,
                DriverID = d.DriverID,
                DriverImg = d.DriverImg,
                BusCode = d.busModel.BusCode,
            }).ToList();
            return driver;
        }

        public DriverShowDataDto GetDriverById(int id)
        {
            var driver = _context.drivers.Include(d => d.busModel).FirstOrDefault(d => d.Id == id);
            if(driver == null) { return null; }
            var driverDto = new DriverShowDataDto
            {
                Id = driver.Id,
                DriverCode = driver.DriverCode,
                DriverName = driver.DriverName,
                DriverPhoneNumber = driver.DriverPhoneNumber,
                DriverAddress = driver.DriverAddress,
                DriverID = driver.DriverID,
                DriverImg = driver.DriverImg,
                BusCode = driver.busModel.BusCode,
            };
            return driverDto;
        }

        public DriverAddDataDto AddDriver(DriverAddDataDto driverDto)
        {
            var bus = _context.buses.FirstOrDefault(b => b.BusCode == driverDto.BusCode);

            if (bus == null)
            {
                return null;
            }

            var driver = new DriverModel
            {
                DriverCode = driverDto.DriverCode,
                DriverName = driverDto.DriverName,
                DriverPhoneNumber = driverDto.DriverPhoneNumber,
                DriverAddress = driverDto.DriverAddress,
                DriverID = driverDto.DriverID,
                BusCode = driverDto.BusCode,
                busModelId = bus.Id,
            };

            _context.drivers.Add(driver);
            _context.SaveChanges();
            return driverDto;
        }

        public DriverAddDataDto UpdateDriver(int id, DriverAddDataDto driverDto)
        {
            var bus = _context.buses.FirstOrDefault(b => b.BusCode == driverDto.BusCode);

            if (bus == null) 
                return null;


            var driver = _context.drivers.Find(id);
            if (driver == null)
                return null;
            

            driver.DriverCode = driverDto.DriverCode;
            driver.DriverName = driverDto.DriverName;
            driver.DriverPhoneNumber = driverDto.DriverPhoneNumber;
            driver.DriverAddress = driverDto.DriverAddress;
            driver.DriverID = driverDto.DriverID;
            driver.BusCode = driverDto.BusCode;
            driver.busModelId = bus.Id;

            _context.drivers.Update(driver);
            _context.SaveChanges();

            return driverDto;
        }

        public bool DeleteDriver(int id)
        {
            var driver = _context.drivers.Find(id);
            if (driver == null)
                return false;

            _context.drivers.Remove(driver);
            _context.SaveChanges();
            return true;
        }

        public bool BusExists(int busCode)
        {
            return _context.buses.Any(b => b.BusCode == busCode);
        }


        string IDriverRepo.UploadImage(int userId, IFormFile file)
        {
           var driver = _context.drivers.FirstOrDefault(x=>x.Id == userId);
            if (driver == null)
            {
                throw new FileNotFoundException("Driver Not Found");
            }

            if (file == null && file.Length == 0)
            {
                throw new BadHttpRequestException("No File Uploaded");
            }

            var UploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(UploadFolder))
            {
                Directory.CreateDirectory(UploadFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(UploadFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            driver.DriverImg = uniqueFileName;
            _context.drivers.Update(driver);
            _context.SaveChanges();
            return filePath;
        }
    }


}
