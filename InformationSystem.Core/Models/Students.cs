namespace InformationSystem.Core.Models
{
    public class Students
    {
        public Students(int id, string firstName, string secondName, string lastName, DateOnly dateOfBirth, string email, int idGroup)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            IdGroup = idGroup;
        }
        public int Id { get; }

        public string FirstName { get; } = string.Empty;

        public string SecondName { get; } = string.Empty;

        public string LastName { get; } = string.Empty;

        public DateOnly DateOfBirth { get; }

        public string Email { get; } = string.Empty;

        public int IdGroup { get; }

        public Groups? Group { get; }

        public List<Subjects>? Subjects { get; }

        public List<ResultSession>? Results { get; }
    }
}
