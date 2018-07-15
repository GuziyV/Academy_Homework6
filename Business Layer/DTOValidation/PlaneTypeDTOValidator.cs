using Data_Access_Layer.Models;
using FluentValidation;

namespace Business_Layer.DTOValidation
{
    public class PlaneTypeDTOValidator : AbstractValidator<PlaneType>
    {
        public PlaneTypeDTOValidator()
        {
            RuleFor(p => p.Model).NotEmpty();
        }
    }
}