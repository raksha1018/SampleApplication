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
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public readonly IStudentRepo<Students> _studentRepo;
        public StudentsController(IStudentRepo<Students> studentRepo)
        {
            _studentRepo = studentRepo;
           
            
        }

        // GET: api/Students
        //[HttpGet]
        //public IEnumerable<Students> Get(int pageNumber=0, string name="")
        //{
        //    return _studentRepo.GetAll(pageNumber, name).ToList();
        //}
        // GET: api/Students
        [HttpGet]
        public StudentData Get([FromQuery]FilteringCriteria pagingParam)
        {
            var result = _studentRepo.GetAll(pagingParam.PageNumber, pagingParam.PageSize, pagingParam.name);          
            return result;

        }
        // GET: api/Students/5
        [HttpGet("{id}", Name = "Get")]
        public Students Get(int id)
        {
            return _studentRepo.GetById(id);
        }
        // POST: api/Students
        [HttpPost]
        public void Post([FromBody] Students students)
        {
            if (ModelState.IsValid)
            {
                _studentRepo.Add(students);
            }       
        }
        // PUT: api/Students/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Students students)
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
