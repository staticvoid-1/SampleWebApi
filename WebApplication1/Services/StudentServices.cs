using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class StudentServices : IStudentsServices

    {
       public List<Student> StudentList { get; }
       public StudentServices()
        {
            this.StudentList = new List<Student>();
            this.StudentList.Add(new Student()
            {
                Name = "Türkcan",
                Surname = "Yılmaz",
                SchoolId = 116
            });
            this.StudentList.Add(new Student()
            {
                Name = "Ece",
                Surname = "Topgüloğlu",
                SchoolId = 117
            });
            this.StudentList.Add(new Student()
            {
                Name = "Ertuğrul",
                Surname = "Özcan",
                SchoolId = 118
            });


        }
    }
}
