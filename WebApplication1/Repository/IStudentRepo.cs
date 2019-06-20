using SampleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Repository
{
    public interface IStudentRepo<T> where T: class
    {
        StudentData GetAll(int pageNumber, int PageSize, string name);
        Students GetById(int id);
        void Add(Students students);
        void Update(int id, Students students);
        void Delete(int id);
    }
}
