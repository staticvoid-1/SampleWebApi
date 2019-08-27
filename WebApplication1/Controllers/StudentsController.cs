using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsApi.Core.Models;
using StudentsWebApi.Models;
using StudentsWebApi.Services.Interfaces;

namespace StudentsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsServices studentService;
        
        public StudentsController(IStudentsServices studentService)
        {
            this.studentService = studentService;
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return this.studentService.GetStudentList();
        }
        
        //POST api/student
        [HttpPost]
        public ActionResult Post(Student student)
        {
            if (string.IsNullOrEmpty(student.Name))
            {
                return this.BadRequest();
            }

            if (string.IsNullOrEmpty(student.Surname))
            {
                return this.BadRequest("Soyisim alanı girilmelidir");
            }

            if (student.SchoolId <= 0 || student.SchoolId > 10000)
            {
                return this.BadRequest("Okul numarası 0 ile 10000 arasında olmalıdır");
            }

            this.studentService.AddStudent(student);

            return this.Ok(student);
        }
        
        //DELETE api/student
        [HttpDelete]
        public ActionResult Delete(RequestModel requestModel)
        {
            var studentList = this.studentService.GetStudentList();
            var student = studentList.FirstOrDefault(x => x.Id == requestModel.StudentId);
            if (student != null)
            {
                this.studentService.DeleteStudent(requestModel.StudentId);

                return this.Ok(student);
            }
            else
            {
                return this.BadRequest();
            }
           
        }
    }
}