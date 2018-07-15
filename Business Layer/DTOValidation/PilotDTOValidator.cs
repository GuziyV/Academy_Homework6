using Data_Access_Layer.Models;
using FluentValidation;

namespace Business_Layer.DTOValidation
{
    public class PilotDTOValidator : AbstractValidator<Pilot>
    {
        public PilotDTOValidator()
        {
            RuleFor(p => p.Surname).NotEmpty();
        }
    }
}