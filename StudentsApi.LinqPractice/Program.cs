using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using StudentsApi.Core.Models;

namespace StudentsApi.LinqPractice
{
	class Program
	{
		static void Main(string[] args)
		{
			string json = File.ReadAllText("C:\\Users\\asus\\Documents\\GitHub\\SampleWebApi\\StudentsApi.LinqPractice\\Resources\\students.json");

			var studentList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(json);
		}

	}
}
