using SampleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IStudentV2Repo<T> where T: class
    {
        IEnumerable<StudentsV2> GetAll(int pageNumber, string name);
        StudentsV2 GetById(int id);
        void Add(StudentsV2 students);
        void Update(int id, StudentsV2 students);
        void Delete(int id);
    }
}
