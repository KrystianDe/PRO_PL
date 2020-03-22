using System;
using System.Collections.Generic;
using Onion.Domain.Entities;
using Onion.Domain.Services;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Onion.Infrastructure.SqlDbService
{
    public class SqlDbService : IStudentDbService
    {
        public bool EnrollStudent(Student newStudent, int semestr)
        {

            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s16891;Integrated Security=True"))
            {

                var com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "INSERT INTO Student( FirstName , LastName ) " +
                                   "VALUES Student( " + newStudent.FirstName + " , " + newStudent.LastName + " ); "
                                     ;

                con.Open();
                com.ExecuteReader();


            }

            return true;
        }

        public IEnumerable<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s16891;Integrated Security=True"))
            {

                var com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "SELECT FirstName , LastName " +
                                    "FROM Student; "
                                      ;


                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    Student tmpStudent = new Student
                    {
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),

                    };

                    students.Add(tmpStudent);

                }
            }

            return students;
        }
    }
}
