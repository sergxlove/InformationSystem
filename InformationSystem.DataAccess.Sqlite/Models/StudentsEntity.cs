namespace InformationSystem.DataAccess.Sqlite.Models
{
    public class StudentsEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string SecondName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateOnly DateOfBirth { get; set; }

        public string Email { get; set; } = string.Empty;

        public int IdGroup { get; set; }

        public GroupsEntity? Group { get; set; }

        public List<SubjectsEntity>? Subjects { get; set; }

        public List<ResultSessionEntity>? Results { get; set; }
    }
}
