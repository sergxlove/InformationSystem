namespace InformationSystem.DataAccess.Sqlite.Models
{
    public class TeachersEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string SecondName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateOnly DateOfBirth { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Departament { get; set; } = string.Empty;

        public List<SubjectsEntity>? Subjects { get; set; }
    }
}
