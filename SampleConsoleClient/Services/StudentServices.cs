using RestSharp;
using StudentsApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleConsoleClient.Services
{
    class StudentServices
    {
        public List<Student> GetStudentList()
        {
            RestClient client = new RestClient("https://localhost:44343/api/student");

            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Charset", "utf-8");
            var response= client.Execute(request);
            if (response.IsSuccessful)
            {
              string json= response.Content;
               return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(json);
            }
            else
            {
                return null;
            }


        }
    }
}
