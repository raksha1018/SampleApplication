using SampleApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace SampleApplication.Repository
{
    public class StudentV2Repo : IStudentV2Repo<StudentsV2>
    {
        private string connectionString;
        public StudentV2Repo()
        {
            connectionString = @"Data Source=WKC001155737\SQLSERVER;Database=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public IEnumerable<StudentsV2> GetAll(int pageNumber = 0, string name = "")
        {
            int rowCount = 3;
            int startIndex = pageNumber * rowCount;
            int endIndex = startIndex + rowCount;
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                IEnumerable<StudentsV2> studentsList = dbConnection.Query<StudentsV2>("SELECT * FROM Student order by FirstName").ToList();
                return studentsList.Skip(startIndex).Take(endIndex).Where(filter => filter.FirstName.Contains(name));
            }
        }
        public StudentsV2 GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = @"Select * from Student where Id= @id";
                dbConnection.Open();
                StudentsV2 student = dbConnection.Query<StudentsV2>(query, new { Id = id }).FirstOrDefault();
                return student;
            }
        }
        public void Add(StudentsV2 students)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "Insert into Student(FirstName, LastName, Age, Department, City) values(@FirstName, @LastName, @Age, @Department, @City)";
                dbConnection.Open();
                dbConnection.Execute(query, students);

            }
        }
        public void Update(int id, StudentsV2 students)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "Update Student set FirstName=@FirstName, LastName=@LastName, Age=@Age, Department=@Department, City=@City where Id=@id";
                dbConnection.Open();
                dbConnection.Execute(query, students);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "Delete from Student where Id=@id";
                dbConnection.Open();
                dbConnection.Execute(query, new { Id = id });
            }
        }



    }
}
