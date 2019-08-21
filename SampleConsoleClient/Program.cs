using SampleConsoleClient.Services;
using StudentsApi.Core.Models;
using System;
using System.Net;

namespace SampleConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
            delegate (
                object s,
                System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                System.Security.Cryptography.X509Certificates.X509Chain chain,
                System.Net.Security.SslPolicyErrors sslPolicyErrors
            ) {
                return true;
            };

            StudentService studentService = new StudentService();
            var students = studentService.GetStudentList();

            Console.WriteLine("İsim giriniz.");
            string name = Console.ReadLine();

            Console.WriteLine("Soyisim giriniz.");
            string surname = Console.ReadLine();

            Console.WriteLine("Okul numarası giriniz.");
            string schoolIdStr = Console.ReadLine();

            int schoolId;

            try
            {
                schoolId = int.Parse(schoolIdStr);
            }
            catch
            {
                schoolId = -1;
                Console.WriteLine("Girdiğiniz veri geçerli değildir.");
            }

            var student = new Student()
            {
                Name = name,
                Surname = surname,
                SchoolId = schoolId
            };
            ResponseResult studentAddingResult = studentService.AddStudent(student);
            if(studentAddingResult.IsSuccessful)
            {
                Console.WriteLine("Öğrenci eklendi.");
            }
            else
            {
                Console.WriteLine("İşlem başarısız: " + studentAddingResult.Message);
            }

            Console.ReadKey();
        }
    }
}
