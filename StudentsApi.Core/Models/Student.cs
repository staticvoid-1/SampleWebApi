using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsApi.Core.Models

{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int SchoolId { get; set; }
    }
}
