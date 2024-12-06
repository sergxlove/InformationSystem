namespace InformationSystem.DataAccess.Sqlite.Models
{
    public class ResultSessionEntity
    {
        public int Id { get; }

        public int IdSubject { get; }

        public int IdStudent { get; }

        public int Semestr { get; }

        public int Grade { get; }

        public DateOnly DateResult { get; }

        public SubjectsEntity? Subjects { get; }

        public StudentsEntity? Students { get; }
    }
}
