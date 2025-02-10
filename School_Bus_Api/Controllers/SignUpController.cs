using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Bus_Api.Dtos.RegistrationDtos;
using School_Bus_Api.Repos.Registration_Repo;

namespace School_Bus_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ISignUpRepo _Repo;
        public SignUpController(ISignUpRepo repo)
        {
            _Repo = repo;
        }

        [HttpPost("Sign Up")]
        public IActionResult SignUp([FromBody] SignUpDto dto)
        {
            _Repo.SignUp(dto);
            return Created();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var s = _Repo.GetAll();
            if (s == null)
            {
                return NotFound("There is no accounts");
            }
            return Ok(new {User = s});
        }
    }
}
