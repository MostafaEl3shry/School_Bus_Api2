using School_Bus_Api.Data;
using School_Bus_Api.Dtos.RegistrationDtos;

namespace School_Bus_Api.Repos.ForgetPassword_Repo
{
    public class ForgetPasswordRepo : IForgetPasswordRepo
    {
        private readonly AppDbContext _context;
        public ForgetPasswordRepo(AppDbContext context)
        {
            _context = context;
        }
        public void ForgetPassword(ForgetPasswordDto dto, int id)
        {
            var forget = _context.registrations.FirstOrDefault(x => x.Id == id);
            if(forget != null)
            {
                dto.studentEmail = forget.studentEmail;
                dto.Password = forget.Password;
                dto.confirmPassword = forget.confirmPassword;

                _context.registrations.Update(forget);
                _context.SaveChanges();
            }
        }

        public List<ForgetPasswordDto> GetAll()
        {
            List<ForgetPasswordDto> forget = _context.registrations
                .Select(x => new ForgetPasswordDto
                {
                    studentEmail = x.studentEmail,
                    Password = x.Password,
                    confirmPassword = x.confirmPassword,
                }).ToList();
            return forget;
        }
    }
}
