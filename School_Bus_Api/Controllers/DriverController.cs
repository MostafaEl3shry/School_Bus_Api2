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

        [HttpGet("get/all")]
        public ActionResult<List<DriverShowDataDto>> GetAllDrivers()
        {
            var drivers = _repository.GetAllDrivers();
            if (drivers == null)
            {
                return NoContent();
            }
            return Ok(new {drivers = drivers});
        }

        [HttpGet("get/{id}")]
        public ActionResult<DriverShowDataDto> GetDriverById(int id)
        {
            var driver = _repository.GetDriverById(id);
            if (driver == null)
                return NoContent();

            return Ok(new {Drivers = driver});
        }

        [HttpPost("post")]
        public ActionResult<DriverAddDataDto> AddDriver(DriverAddDataDto driverDto)
        {
            if (!_repository.BusExists(driverDto.BusCode))
            {
                return BadRequest("BusCode does not exist.");
            }

            _repository.AddDriver(driverDto);

            return Created();
        }

        [HttpPost("upload")]
        public IActionResult UploadImage([FromForm]UploadImageDto dto)
        {
            try
            {
                var filePath = _repository.UploadImage(dto.DriverId, dto.File);
                return Ok(new { message = "File uploaded successfully.", filePath });
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }

        [HttpPut("put/{id}")]
        public IActionResult UpdateDriver(int id, DriverAddDataDto driverDto)
        {
            var driver = _repository.GetDriverById(id);
            if (driver == null)
                return NotFound();

            _repository.UpdateDriver(id, driverDto);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteDriver(int id)
        {
            var deleted = _repository.DeleteDriver(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }

}
