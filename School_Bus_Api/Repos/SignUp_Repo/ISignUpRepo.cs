using School_Bus_Api.Dtos.RegistrationDtos;

namespace School_Bus_Api.Repos.Registration_Repo
{
    public interface ISignUpRepo
    {
        public void SignUp(SignUpDto dto);
        public List<SignUpDto> GetAll();
    }
}
