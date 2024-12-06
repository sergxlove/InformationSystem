namespace InformationSystem.Core.Models
{
    public class ResultSession
    {
        public int Id { get; }

        public int IdSubject { get; }

        public int IdStudent { get; }

        public int Semestr { get; }

        public int Grade { get; }

        public DateOnly DateResult { get; }

        public Subjects? Subjects { get; }

        public Students? Students { get; }
    }
}
