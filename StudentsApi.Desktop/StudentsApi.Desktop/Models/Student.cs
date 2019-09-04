using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsApi.Desktop.Models
{
    public enum Departments
    {
        ComputerEngineering,
        MathematicalEngineering,
        MechanicalEngineering,
        ElectronicsEngineering,
        ElectricalEngineering
    };

    public enum Semesters
    {
        A1,
        S1,
        A2,
        S2,
        A3,
        S3,
        A4,
        S4
    };

    public class Student
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("schoolid")]
        public int SchoolId { get; set; }

        [JsonProperty("birthdate")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("department")]
        public Departments Department { get; set; }

        [JsonProperty("currentsemester")]
        public Semesters CurrentSemester { get; set; }


    }
}
