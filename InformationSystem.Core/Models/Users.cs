namespace InformationSystem.Core.Models
{
    public class Users
    {
        public int Id { get; }

        public string Login { get; } = string.Empty;

        public string Password { get; } = string.Empty;

        public string Role { get; } = string.Empty;
    }
}
