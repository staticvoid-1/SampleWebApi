using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IStudentsServices
    {
        List<Student> StudentList { get; }
    }
}
