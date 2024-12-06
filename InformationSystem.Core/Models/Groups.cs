namespace InformationSystem.Core.Models
{
    public class Groups
    {
        public Groups(int id, string name, string specialization)
        {
            Id = id;
            Name = name;
            Specialization = specialization;
        }
        public int Id { get; }

        public string Name { get; } = string.Empty;

        public string Specialization { get; } = string.Empty;

        public List<Students>? Students { get; }
    }
}
