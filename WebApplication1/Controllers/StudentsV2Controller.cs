using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models;


namespace SampleApplication.Controllers
{
    //[Route("api/[controller]")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/students")]
    [ApiController]
    public class StudentsV2Controller : ControllerBase
    {
        public readonly IStudentV2Repo<StudentsV2> _studentRepo;
        public StudentsV2Controller(IStudentV2Repo<StudentsV2> studentRepo)
        {
            _studentRepo = studentRepo;
        }
        // GET: api/StudentsV2
        [HttpGet]
        public IEnumerable<StudentsV2> Get(int pageNumber = 0, string name = "")
        {
            return _studentRepo.GetAll(pageNumber, name).ToList();

        }
        // GET: api/StudentsV2/5
        [HttpGet("{id}", Name = "Get")]
        public StudentsV2 Get(int id)
        {
            return _studentRepo.GetById(id);
        }
        // POST: api/StudentsV2
        [HttpPost]
        public void Post([FromBody] StudentsV2 students)
        {
            if (ModelState.IsValid)
            {
                _studentRepo.Add(students);
            }
        }
        // PUT: api/StudentsV2/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StudentsV2 students)
        {
            students.Id = id;
            if (ModelState.IsValid)
            {
                _studentRepo.Update(id, students);
            }
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _studentRepo.Delete(id);
        }
    }
}
