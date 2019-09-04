using System.Collections.Generic;
using System.Linq;
using StudentsApi.Core.Models;
using StudentsWebApi.Services.Interfaces;

namespace StudentsWebApi.Services
{
    public class StudentServices : IStudentsServices
    {
        private List<Student> StudentList { get; }
        
        public StudentServices()
        {
            this.StudentList = new List<Student>
            {
                new Student()
                {
                    Id = 1000, 
                    Name = "Türkcan", 
                    Surname = "Yılmaz", 
                    SchoolId = 116
                }, 
                new Student()
                {
                    Id = 1001, 
                    Name = "Ece", 
                    Surname = "Topgüloğlu", 
                    SchoolId = 117
                }, 
                new Student()
                {
                    Id = 1002, 
                    Name = "Ertuğrul", 
                    Surname = "Özcan", 
                    SchoolId = 118
                }
            };
        }

        public List<Student> GetStudentList()
        {
            return this.StudentList;
        }

        public void AddStudent(Student student)
        {
            var OrderedStudentList = this.StudentList.OrderBy(x => x.Id);
            var LastStudent = OrderedStudentList.Last();
            student.Id = LastStudent.Id + 1;

            this.StudentList.Add(student);
        }

        public void DeleteStudent(int id)
        {
            var student = this.StudentList.FirstOrDefault(x => x.Id == id);
            this.StudentList.Remove(student);
        }
    }
}
