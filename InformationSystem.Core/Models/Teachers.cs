namespace InformationSystem.Core.Models
{
    public class Teachers
    {
        public int Id { get; }

        public string FirstName { get; } = string.Empty;

        public string SecondName { get; } = string.Empty;

        public string LastName { get; } = string.Empty;

        public DateOnly DateOfBirth { get; }

        public string Email { get; } = string.Empty;

        public string Departament { get; } = string.Empty;

        public List<Subjects>? Subjects { get; }
    }
}
