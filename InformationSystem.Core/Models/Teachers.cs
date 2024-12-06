namespace InformationSystem.Core.Models
{
    public class Teachers
    {
        public Teachers(int id, string firstName, string secondName, string lastName, DateOnly dateOfBirth,
            string email, string departament)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            Departament = departament;
        }
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
