namespace InformationSystem.Core.Models
{
    public class ResultSession
    {
        public ResultSession(int id, int idSubject, int idStudent, int semestr, int grade, DateOnly dateResult) 
        {
            Id = id;
            IdSubject = idSubject;
            IdStudent = idStudent;
            Semestr = semestr;
            Grade = grade;
            DateResult = dateResult;
        }
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
