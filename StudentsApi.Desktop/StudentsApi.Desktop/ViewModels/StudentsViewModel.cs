using StudentsApi.Desktop.Models;
using StudentsApi.Desktop.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsApi.Desktop.ViewModels
{
    public class StudentsViewModel
    {
        private readonly StudentService studentService;

        public ObservableCollection<Student> StudentList { get; set; }

        public StudentsViewModel()
        {
            this.studentService = new StudentService();

            var studentList = this.studentService.GetStudentList();
            this.StudentList = new ObservableCollection<Student>(studentList);
        }
    }
}
