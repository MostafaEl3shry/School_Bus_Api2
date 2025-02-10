using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Bus_Api.Dtos.DriverDtos;
using School_Bus_Api.Model;
using School_Bus_Api.Repos.Driver_Repo;

namespace School_Bus_Api.Controllers
{
    [Route("api/drivers")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriverRepo _repository;

        public DriversController(IDriverRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<DriverShowDataDto>> GetAllDrivers()
        {
            var drivers = _repository.GetAllDrivers();
            if (drivers == null)
            {
                return NoContent();
            }
            return Ok(new {drivers = drivers});
        }

        [HttpGet("{id}")]
        public ActionResult<DriverShowDataDto> GetDriverById(int id)
        {
            var driver = _repository.GetDriverById(id);
            if (driver == null)
                return NoContent();

            return Ok(new {Drivers = driver});
        }

        [HttpPost]
        public ActionResult<DriverAddDataDto> AddDriver(DriverAddDataDto driverDto)
        {
            if (!_repository.BusExists(driverDto.BusCode))
            {
                return BadRequest("BusCode does not exist.");
            }

            _repository.AddDriver(driverDto);

            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDriver(int id, DriverAddDataDto driverDto)
        {
            var driver = _repository.GetDriverById(id);
            if (driver == null)
                return NotFound();

            _repository.UpdateDriver(id, driverDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDriver(int id)
        {
            var deleted = _repository.DeleteDriver(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }

}
