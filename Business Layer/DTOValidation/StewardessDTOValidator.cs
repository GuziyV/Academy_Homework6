using Data_Access_Layer.Models;
using FluentValidation;

namespace Business_Layer.DTOValidation
{
    public class StewardessDTOValidator : AbstractValidator<Stewardess>
    {
        public StewardessDTOValidator()
        {
            RuleFor(s => s.Surname).NotEmpty();
        }
    }
}