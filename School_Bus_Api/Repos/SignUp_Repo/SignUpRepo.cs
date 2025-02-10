using Microsoft.AspNetCore.Http.HttpResults;
using School_Bus_Api.Data;
using School_Bus_Api.Dtos.RegistrationDtos;
using School_Bus_Api.Model;

namespace School_Bus_Api.Repos.Registration_Repo
{
    public class SignUpRepo : ISignUpRepo
    {
        private readonly AppDbContext _context;
        public SignUpRepo(AppDbContext context)
        {
            _context = context;
        }
        public List<SignUpDto> GetAll()
        {
            List<SignUpDto> sign = _context.registrations.Select(x => new SignUpDto
            {
                studentName = x.studentName,
                studentPhoneNumber = x.studentPhoneNumber,
                studentEmail = x.studentEmail,
                Password = x.Password,
                confirmPassword = x.confirmPassword,
                parentName = x.parentName,
                parentPhoneNumber = x.parentPhoneNumber,
                Address = x.Address
            }).ToList();

            return sign;
        }

        public void SignUp(SignUpDto dto)
        {
            var sign = new RegistrationModel
            {
                studentName = dto.studentName,
                studentPhoneNumber = dto.studentPhoneNumber,
                studentEmail = dto.studentEmail,
                Password = dto.Password,
                confirmPassword = dto.confirmPassword,
                parentName = dto.parentName,
                parentPhoneNumber = dto.parentPhoneNumber,
                Address = dto.Address,
            };
            _context.registrations.Add(sign);
            _context.SaveChanges();
        }
    }
}
