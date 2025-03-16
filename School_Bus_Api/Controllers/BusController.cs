using Microsoft.AspNetCore.Mvc;
using School_Bus_Api.Dtos.BusDtos;
using School_Bus_Api.Model;
using School_Bus_Api.Repos.Bus_Repo;
using System.Collections.Generic;
using System.Linq;

namespace School_Bus_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusRepo _busRepository;

        public BusController(IBusRepo busRepository)
        {
            _busRepository = busRepository;
        }

        [HttpGet("get/all")]
        public ActionResult<List<BusShowDataDto>> GetBuses()
        {
            return Ok(new {Bus = _busRepository.GetAllBuses()});
        }

        [HttpGet("get/{id}")]
        public ActionResult<BusDto> GetBus(int id)
        {
            var bus = _busRepository.GetBusById(id);
            if (bus == null)
                return NotFound();

            return Ok(new {Bus = bus});
        }

        [HttpPost("Add")]
        public IActionResult CreateBus([FromBody] BusDto busDto)
        {
            var buses = _busRepository.GetAllBuses().Any(b => b.BusCode == busDto.BusCode);
            if (buses)
                return BadRequest("Bus Code must be unique.");

            _busRepository.AddBus(busDto);

            return Created();
        }

        [HttpPut("Put/{id}")]
        public IActionResult UpdateBus(int id, [FromBody] BusDto busDto)
        {
            var existingBus = _busRepository.GetBusById(id);
            if (existingBus == null)
                return NotFound();


            _busRepository.UpdateBus(id,existingBus);

            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteBus(int id)
        {
            if (_busRepository.GetBusById(id) == null)
                return NotFound();

            _busRepository.DeleteBus(id);
            return NoContent();
        }
    }
}
