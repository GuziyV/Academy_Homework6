using Data_Access_Layer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer.DTOValidation
{
    public class CrewDTOValidator : AbstractValidator<Crew>
    {
        public CrewDTOValidator()
        {
            RuleFor(c => c.Pilot).NotNull();
            RuleFor(c => c.Stewardesses).NotNull().NotEmpty();
        }
    }
}