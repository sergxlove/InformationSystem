namespace InformationSystem.DataAccess.Sqlite.Models
{
    public class GroupsEntity
    {
        public int Id { get; set; }

        public string Name { get; set;  } = string.Empty;

        public string Specialization { get; set;  } = string.Empty;

        public List<StudentsEntity>? Students { get; set; }
    }
}
