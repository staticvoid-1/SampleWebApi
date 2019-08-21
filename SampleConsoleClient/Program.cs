using SampleConsoleClient.Services;
using StudentsApi.Core.Models;
using System;

namespace SampleConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
           StudentServices studentService=new StudentServices();
           var students = studentService.GetStudentList();
            

            Console.WriteLine("İsim giriniz:");
            string name = Console.ReadLine();

            Console.WriteLine("Soyisim giriniz:");
            string surname = Console.ReadLine();

            Console.WriteLine("Okul no giriniz:");
            string schoolIdStr = Console.ReadLine();

            int schoolId;

            try
            {
               schoolId = int.Parse(schoolIdStr);
            }
            catch
            {
                schoolId = -1;
                Console.WriteLine("Girilen okul nosu geçerli değildir.");
            }
           

            var student = new Student()
            {
                Name = name,
                Surname = surname,
                SchoolId = schoolId
            };
           ResponseResult studentAddingResult = studentService.AddStudent(student);
            if (studentAddingResult.IsSuccessful)
            {
                Console.WriteLine("Öğrenci eklendi.");
            }
            else
            {
                Console.WriteLine("İşlem başarısız oldu :"+studentAddingResult.Message);
            }
               
        }
    }
}
