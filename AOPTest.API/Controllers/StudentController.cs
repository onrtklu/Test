using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AOPTest.API.DTOs;
using AOPTest.API.Filters;
using AOPTest.API.Model;
using AOPTest.API.Services;
using AOPTest.API.Validations;
using Microsoft.AspNetCore.Mvc;

namespace AOPTest.API.Controllers
{
    // [DefaultResponse]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : BaseController
    {
        private readonly ILogModel _logModel;
        private readonly IStudentService _studentService;
        
        public StudentController(ILogModel logModel, IStudentService studentService) 
        {
            _logModel = logModel;
            _studentService = studentService;
        }

        // [TypeFilter(typeof(LogAttribute), Arguments = new object[] {"student-insert"})]
        [FluentValidate(typeof(StudentDtoValidation))]
        [HttpPost]
        public async Task<IActionResult> Insert([FromHeader] string language, int id, StudentDto model)
        {
            _studentService.InsertStudent(model);
            return Ok(model);
        }
    }
}