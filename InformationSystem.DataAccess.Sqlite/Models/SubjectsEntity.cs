namespace InformationSystem.DataAccess.Sqlite.Models
{
    public class SubjectsEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int IdTeacher { get; set; }

        public List<StudentsEntity>? Students { get; set; }

        public TeachersEntity? Teachers { get; set; }

        public List<ResultSessionEntity>? Results { get; set; }
    }
}
