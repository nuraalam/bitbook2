using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HelloWorldInASPDOTNetMVC.Models
{
    public class StudentContainer
    {
        public List<Student> GetStudents()
        {

            List<Student> students = new List<Student>();

            string connectionStrings = @"Server=Hafiz;Database=UniversityDB;Integrated security=True";
            SqlConnection aConnection=new SqlConnection(connectionStrings);
            aConnection.Open();
            SqlCommand aCommand=new SqlCommand("SELECT*FROM newStudent",aConnection);
            SqlDataReader reader = aCommand.ExecuteReader();

            while (reader.Read())
            {
                Student aStudent=new Student();
                aStudent.Name = reader[0].ToString();
                aStudent.Email = reader[1].ToString();
                students.Add(aStudent);
            }


            aConnection.Close();

            return students;
        }

        public void SaveStudent(Student aStudent)
        {
            string connectionStrings = @"Server=Hafiz;Database=UniversityDB;Integrated security=True";
            SqlConnection aConnection = new SqlConnection(connectionStrings);
            aConnection.Open();
            SqlCommand aCommand = new SqlCommand("Insert INTO newStudent values('"+aStudent.Name+"','"+aStudent.Email+"','"+aStudent.PostedDate+"')", aConnection);
            aCommand.ExecuteNonQuery();
            aConnection.Close();

        }
    }
}