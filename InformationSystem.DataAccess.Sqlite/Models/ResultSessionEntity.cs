namespace InformationSystem.DataAccess.Sqlite.Models
{
    public class ResultSessionEntity
    {
        public int Id { get; set; }

        public int IdSubject { get; set; }

        public int IdStudent { get; set; }

        public int Semestr { get; set; }

        public int Grade { get; set; }

        public DateOnly DateResult { get; set; }

        public SubjectsEntity? Subjects { get; set; }

        public StudentsEntity? Students { get; set; }
    }
}
