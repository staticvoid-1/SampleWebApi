using System.Collections.Generic;
using StudentsApi.Core.Models;

namespace StudentsWebApi.Services.Interfaces
{
    public interface IStudentsServices
    {
        List<Student> GetStudentList();

        void AddStudent(Student student);
        
        void DeleteStudent(int id);
    }
}
