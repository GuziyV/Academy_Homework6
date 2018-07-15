using Data_Access_Layer.Models;
using FluentValidation;

namespace Business_Layer.DTOValidation
{
    public class TicketDTOValidator : AbstractValidator<Ticket>
    {
        public TicketDTOValidator()
        {
            RuleFor(t => t.FlightNumber).NotEqual(0);
        }
    }
}