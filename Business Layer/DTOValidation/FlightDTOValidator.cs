using Data_Access_Layer.Models;
using FluentValidation;

namespace Business_Layer.DTOValidation
{
    public class FlightDTOValidator : AbstractValidator<Flight>
    {
        public FlightDTOValidator()
        {
            RuleFor(f => f.DepartureFrom).NotEmpty();
            RuleFor(f => f.Destination).NotEmpty();
        }
    }
}