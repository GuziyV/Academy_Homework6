using Data_Access_Layer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer.DTOValidation
{
    public class DepartureDTOValidator : AbstractValidator<Departure>
    {
        public DepartureDTOValidator()
        {
            RuleFor(d => d.Crew).NotNull();
            RuleFor(d => d.Flight).NotNull();
            RuleFor(d => d.Plane).NotNull();
        }
    }
}