using School_Bus_Api.Data;
using School_Bus_Api.Model;

namespace School_Bus_Api.Repos.Login_Repo
{
    public class LoginRepo : ILoginRepo
    {
        private readonly AppDbContext _context;
        public LoginRepo(AppDbContext context)
        {
            _context = context;
        }
        public bool Login(string Email, string password)
        {
            var login = _context.registrations.FirstOrDefault(x => x.studentEmail == Email && x.Password == password);
            if (login != null)
            {
                return true;
            }
            return false;
        }
    }
}
