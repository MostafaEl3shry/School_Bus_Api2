using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Bus_Api.Dtos.RegistrationDtos;
using School_Bus_Api.Repos.ForgetPassword_Repo;

namespace School_Bus_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgetPasswordController : ControllerBase
    {
        private readonly IForgetPasswordRepo _repo;
        public ForgetPasswordController(IForgetPasswordRepo repo)
        {
            _repo = repo;
        }

        [HttpPut("put")]
        public IActionResult UpdatePassword([FromBody] ForgetPasswordDto dto, int id)
        {
            _repo.ForgetPassword(dto, id);
            return Ok();
        }

        [HttpGet("get/all")]
        public IActionResult Get()
        {
            return Ok(_repo.GetAll());
        }
    }
}
