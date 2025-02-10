namespace School_Bus_Api.Repos.Login_Repo
{
    public interface ILoginRepo
    {
        public bool Login(string Email, string password);
    }
}
