using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Bus_Api.Repos.Login_Repo;
using School_Bus_Api.Repos.Registration_Repo;

namespace School_Bus_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepo _Repo;
        public LoginController(ILoginRepo repo)
        {
            _Repo = repo;
        }

        [HttpPost]
        public IActionResult Login(string email,string password)
        {
            var l = _Repo.Login(email, password);
            if(l == null)
            {
                return NoContent();
            }
            return Ok(new { status = l });
        }
    }
}
