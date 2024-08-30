using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;
using System.Xml.Linq;

namespace MVCwithAdo.net.Models
{
    public class StudentDbContext
    {
        string cs = "Server=localhost;Port=5432;Database=ado_dbms;UserId=postgres;Password=1234";

        public List<Student> GetStudents() 
        {
            List<Student> studentList = new List<Student>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from student", con);
            con.Open();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
                Student student = new Student();
                student.id = Convert.ToInt32(reader.GetValue(0).ToString());
                student.name = reader.GetValue(1).ToString();
                student.gender = reader.GetValue(2).ToString();
                student.age = Convert.ToInt32(reader.GetValue(3).ToString());
                student.city = reader.GetValue(4).ToString();
                studentList.Add(student);
            }
            con.Close();
            return studentList;   
        }

        public bool AddStudent(Student student)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("insert into Student values(@id, @name, @gender, @age, @city)", con);
            cmd.Parameters.AddWithValue("@id", student.id);
            cmd.Parameters.AddWithValue("@name", student.name);
            cmd.Parameters.AddWithValue("@gender", student.gender);
            cmd.Parameters.AddWithValue("@age", student.age);
            cmd.Parameters.AddWithValue("@city", student.city);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateStudent(Student student) 
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("update student set name = @name, gender = @gender, age = @age, city = @city where id = @id", con);
            cmd.Parameters.AddWithValue("@id", student.id);
            cmd.Parameters.AddWithValue("@name", student.name);
            cmd.Parameters.AddWithValue("@gender", student.gender);
            cmd.Parameters.AddWithValue("@age", student.age);
            cmd.Parameters.AddWithValue("@city", student.city);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0) 
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool DeleteStudent(int id)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("Delete from student where id = @id", con);
            cmd.Parameters.AddWithValue("@id",id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
