using School_Bus_Api.Dtos.RegistrationDtos;

namespace School_Bus_Api.Repos.ForgetPassword_Repo
{
    public interface IForgetPasswordRepo
    {
        public void ForgetPassword(ForgetPasswordDto dto,int id);
        public List<ForgetPasswordDto> GetAll();
    }
}
