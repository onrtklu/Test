using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AOPTest.API.DTOs;

namespace AOPTest.API.Services
{
    public interface IStudentService
    {
        void InsertStudent(StudentDto model);
    }

    public class StudentService : IStudentService
    {
        public void InsertStudent(StudentDto model)
        {
            
        }
    }
}