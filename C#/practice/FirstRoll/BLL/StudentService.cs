using System;

using Exceptions;
using Models;
using DAL;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
    class StudentService
    {
        private static readonly StudentRepository _repo = new StudentRepository();

        public void GetStudents()
        {
            List<Student> students = _repo.GetAll();

            foreach (var student in students)
            {
                Console.WriteLine(
                    $"ID : {student.Id}, Name : {student.Name}, Age : {student.Age}, Email : {student.Email}"
                );
            } 
        }
        public void AddStudent()
        {
            Console.Write("Enter Student Id: ");
            if(!int.TryParse(Console.ReadLine(),out int id))
            {
                throw new InvalidInputTypeException("Invalid Parameter Type ...");
            }

            Console.Write("Enter Student Name: ");
            string name = Regex.Replace(Console.ReadLine(),"[^A-Za-z ]",string.Empty);
            
            Console.Write("Enter Student Age: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int age))
            {
                throw new InvalidInputTypeException("Age must be a valid integer.");
            }

            if (age < 0)
            {
                throw new InvalidAgeException("Invalid age: Age cannot be negative.");
            }

            Console.Write("Enter Student Email: ");
            string email = Regex.Replace(Console.ReadLine(),"[^A-Za-z0-9._@-]",string.Empty);

            _repo.Add(new Student {Id = id , Name = name , Age = age, Email = email});           
        }
        public void UpdateStudent()
        {
            Console.Write("Enter ID of the Stuent to Update (Name): ");
            if(!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new InvalidInputTypeException (" Invalid ID (Update Operation)");
            }
            
            Console.Write("Enter Student Name: ");
            string name = Regex.Replace(Console.ReadLine(),"[^A-Za-z ]",string.Empty);
            
            Console.Write("Enter Student Age: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int age))
            {
                throw new InvalidInputTypeException("Age must be a valid integer.");
            }

            if (age < 0)
            {
                throw new InvalidAgeException("Invalid age: Age cannot be negative.");
            }

            Console.Write("Enter Student Email: ");
            string email = Regex.Replace(Console.ReadLine(),"[^A-Za-z0-9._@-]",string.Empty);

             _repo.Update(new Student {Id = id , Name = name , Age = age, Email = email});
        }
        public void DeleteStudent()
        {
            Console.Write("Enter ID of the Stuent to Update (Name): ");
            if(!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new InvalidInputTypeException (" Invalid ID (Update Operation)");
            }
            _repo.Delete(id);
        }
        public void SearchStudent()
        {
            Console.Write("Enter ID of the Stuent to Update (Name): ");
            if(!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new InvalidInputTypeException (" Invalid ID (Update Operation)");
            }

            var student = _repo.Search(id);

            if(student == null)
            {
                Console.WriteLine("No Student found in that ID !");
            }
            else
            {
            Console.WriteLine(
                    $"ID : {student.Id}, Name : {student.Name}, Age : {student.Age}, Email : {student.Email}"
                );
            }
            
        }
    }
}