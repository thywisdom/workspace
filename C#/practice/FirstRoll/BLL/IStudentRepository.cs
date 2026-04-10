using System.Collections.Generic;

using Models;

namespace BLL
{
    public interface IStudentRepository
    {
        void Add(Student student);
        List<Student> GetAll();
        void Delete(int id);
        Student Search(int id);
        void Update(Student student);
    }
}