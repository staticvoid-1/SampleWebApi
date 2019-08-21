using System;
using SampleConsoleClient.Services;
using StudentsApi.Core.Models;

namespace SampleConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentService studentService = new StudentService();
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
                Console.WriteLine("Girilen değer geçersiz!");
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
                Console.WriteLine("İşlem başarısız. : " + studentAddingResult.Message);
            }
        }
    }
}
