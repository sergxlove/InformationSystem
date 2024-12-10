namespace InformationSystem.Core.Models
{
    public class Users
    {
        public Users(int id, string login, string password, string role)
        {
            Id = id;
            Login = login;
            Password = password;
            Role = role;
        }
        public int Id { get; }

        public string Login { get; } = string.Empty;

        public string Password { get; } = string.Empty;

        public string Role { get; } = string.Empty;
    }
}
