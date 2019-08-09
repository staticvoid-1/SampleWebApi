using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentsServices studentService;
        public StudentController(IStudentsServices studentService)
        {
            this.studentService = studentService;

        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return this.studentService.StudentList;
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

            if(student.SchoolId <= 0 || student.SchoolId > 10000)
            {
                return this.BadRequest("Okul numarası 0 ile 10000 arasında olmalıdır");
            }

            this.studentService.StudentList.Add(student);

            return this.Ok();
        }
    }
}