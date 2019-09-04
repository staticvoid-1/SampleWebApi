﻿using RestSharp;
using StudentsApi.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsApi.Desktop.Services
{
    public class StudentService
    {
        public List<Student> GetStudentList()
        {
            RestClient client = new RestClient("https://localhost:44393/api/students");

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
            RestClient client = new RestClient("http://localhost:5900/api/student");

            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Charset", "utf-8");

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(student);
            request.AddJsonBody(json);

            var response = client.Execute(request);
            if (response.IsSuccessful)
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
