using RestSharp;
using StudentsApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleConsoleClient.Services
{
    class StudentService
    {
        public List<Student> GetStudentList()
        {
            RestClient client = new RestClient("https://localhost:44343/api/student");

            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Charset", "utf-8");

            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                string json = response.Content;
                var studentList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(json);
                return studentList;
            }
            else
            {
                return null;
            }
        }

        public ResponseResult AddStudent(Student student)
        {
            RestClient client = new RestClient("https://localhost:44343/api/student");

            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Charset", "utf-8");

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(student);
            request.AddJsonBody(json);

            var response = client.Execute(request);
            if(response.IsSuccessful)
            {
                return new ResponseResult(true);
            }
            else
            {
                return new ResponseResult(false, response.ErrorMessage);
            }
        }
    }
}
