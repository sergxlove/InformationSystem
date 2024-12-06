namespace InformationSystem.Core.Models
{
    public class Subjects
    {
        public Subjects(int id, string name, string description, int idTeacher)
        {
            Id = id;
            Name = name;
            Description = description;
            IdTeacher = idTeacher;
        }
        public int Id { get; }

        public string Name { get; } = string.Empty;

        public string Description { get; } = string.Empty;

        public int IdTeacher { get; }

        public List<Students>? Students { get; }

        public Teachers? Teachers { get; }

        public List<ResultSession>? Results { get; }
    }
}
