using Data_Access_Layer.Models;
using FluentValidation;

namespace Business_Layer.DTOValidation
{
    public class PlaneDTOValidator : AbstractValidator<Plane>
    {
        public PlaneDTOValidator()
        {
            RuleFor(p => p.PlaneType).NotNull();
        }
    }
}