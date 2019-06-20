using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SampleApplication.Models;

namespace SampleApplication.Repository
{
    public class StudentRepo : IStudentRepo<Students>
    {
        private string connectionString;
        public StudentRepo()
        {
          //connectionString = @"Data Source=WKC001155737\SQLSERVER;Database=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
         connectionString = ConfigurationManager.ConnectionStrings["SqlConString"].ConnectionString; 
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        public StudentData GetAll(int pageNumber,int pageSize, string name="")
        {
           // int rowCount = 3;
            int startIndex = (pageNumber - 1) * pageSize;
            int endIndex = pageSize;
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var studentsList = dbConnection.Query<Students>("SELECT * FROM Student order by FirstName").ToList();
                var result =studentsList.Skip(startIndex).Take(endIndex).Where(m=>m.FirstName.Contains(name));
                var student = new StudentData();
                student.studentCollection = result;
                student.previousPage = pageNumber - 1;
                student.nextPage = pageNumber +1;
                student.totalRecords = studentsList.Count;
                student.currentPage = pageNumber;
                student.pageSize = pageSize;
                return student;             
            }
        }
        public Students GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = @"Select * from Student where Id= @id";
                dbConnection.Open();
                Students student = dbConnection.Query<Students>(query, new { Id = id }).FirstOrDefault();
                return student;
            }
        }
        public void Add(Students students)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "Insert into Student(FirstName, LastName, Age, Department) values(@FirstName, @LastName, @Age, @Department)";
                dbConnection.Open();
                dbConnection.Execute(query, students);
                
            }
        }
        public void Update(int id, Students students)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "Update Student set FirstName=@FirstName, LastName=@LastName, Age=@Age, Department=@Department where Id=@id";
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
