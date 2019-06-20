using SampleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IStudentRepo<T> where T: class
    {
        StudentData GetAll(int pageNumber, int pageSize, string name);
        Students GetById(int id);
        void Add(Students students);
        void Update(int id, Students students);
        void Delete(int id);
    }
}
