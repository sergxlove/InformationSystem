namespace InformationSystem.DataAccess.Sqlite.Models
{
    public class UsersEntity
    {
        public int Id { get; set; }

        public string Login { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
    }
}
