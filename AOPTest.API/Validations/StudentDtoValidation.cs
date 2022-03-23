using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AOPTest.API.DTOs;
using FluentValidation;

namespace AOPTest.API.Validations
{
    public class StudentDtoValidation : AbstractValidator<StudentDto>
    {
        public StudentDtoValidation()
        {
            RuleFor(x=>x.Name).NotNull().NotEmpty();
            RuleFor(x=>x.Age).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}