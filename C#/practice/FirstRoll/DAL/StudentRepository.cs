using System;
using System.Data.SqlClient;

using Exceptions;
using Models;
using BLL;
using DCL;
using System.Data.Common;


namespace DAL
{
    class StudentRepository : IStudentRepository
    {   
        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();

            using var con = DBconnnect.GetConnection();
            con.Open();

            string query = "SELECT * FROM Students";
            SqlCommand cmd = new(query,con);
            SqlDataReader rd = cmd.ExecuteReader();

            while(rd.Read())
            {
                students.Add
                (new Student
                    { 
                        Id = (int)rd["Id"],
                        Name = rd["Name"].ToString(),
                        Age = (int)rd["Age"],
                        Email = rd["Email"].ToString()
                    }
                );
            }
            return students;
        }
        public void Add(Student student)
        {
            using var con = DBconnnect.GetConnection();
            con.Open();

            string query= "INSERT INTO Students(Name, Age, Email) VALUES (@Name, @Age, @Email)";

            SqlCommand cmd = new SqlCommand(query,con);

            //cmd.Parameters.AddWithValue("@Id",student.Id);
            cmd.Parameters.AddWithValue("@Name",student.Name);
            cmd.Parameters.AddWithValue("@Age",student.Age);
            cmd.Parameters.AddWithValue("@Email",student.Email);

            cmd.ExecuteNonQuery();
        }

        public void Update (Student student)
        {
            using var con = DBconnnect.GetConnection();
            con.Open();

            string query= "UPDATE Students SET Name = @Name, Age = @Age, Email = @Email WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(query,con);

            cmd.Parameters.AddWithValue("@Id",student.Id);
            cmd.Parameters.AddWithValue("@Name",student.Name);
            cmd.Parameters.AddWithValue("@Age",student.Age);
            cmd.Parameters.AddWithValue("@Email",student.Email);

            cmd.ExecuteNonQuery();
        }

        public void Delete (int id)
        {
            using var con = DBconnnect.GetConnection();
            con.Open();

            string query= "DELETE FROM Students WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(query,con);

            cmd.Parameters.AddWithValue("@Id",id);

            cmd.ExecuteNonQuery();
        }
        
        public Student Search(int id)
        {
            using var con = DBconnnect.GetConnection();
            con.Open();

            string query = "SELECT TOP(1) * FROM Students WHERE Id = @Id";
            SqlCommand cmd = new(query,con);
            cmd.Parameters.AddWithValue("@Id",id);

            SqlDataReader rd = cmd.ExecuteReader();

            if(rd.Read())
            {
                
                var student = new Student
                    { 
                        Id = (int)rd["Id"],
                        Name = rd["Name"].ToString(),
                        Age = (int)rd["Age"],
                        Email = rd["Email"].ToString()
                    };
                return student;
            }
            return null;
        }

    }
}
