using SampleConsoleClient.Services;
using System;

namespace SampleConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
           StudentServices studentService=new StudentServices();
            var students = studentService.GetStudentList();
            Console.WriteLine(students.Count);
        }
    }
}
