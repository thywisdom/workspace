namespace mvc_eg.Models
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> Datasource()
        {
            return new List<Student>()
            {
                new Student() { StudentId = 1, Name = "John", Branch = "CSE", Section = "A", Gender = "Male" },
                new Student() { StudentId = 2, Name = "xyz", Branch = "CSE", Section = "A", Gender = "Male" },
                new Student() { StudentId = 3, Name = "abc", Branch = "CSE", Section = "A", Gender = "Male" },
                new Student() { StudentId = 4, Name = "pqr", Branch = "CSE", Section = "A", Gender = "Male" }
            };


        }
        public Student getStudentById(int StudentId)
        {
            return Datasource().FirstOrDefault(s => s.StudentId == StudentId) ?? new Student();

        }
    }
}

