namespace mvc_eg.Models
{
    public interface IStudentRepository
    {
        Student getStudentById(int StudentId);
            //List<Student> getAllStudents();
    }

}
