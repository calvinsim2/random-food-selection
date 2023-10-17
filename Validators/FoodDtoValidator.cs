using FluentValidation;
using RandomFoodSelection.Dto;
using System.Diagnostics.CodeAnalysis;

namespace RandomFoodSelection.Validators
{
    [ExcludeFromCodeCoverage]
    public class FoodDtoValidator : AbstractValidator<FoodDto>
    {
        public FoodDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name - cannot be empty");
            RuleFor(x => x.Cuisine).NotEmpty().WithMessage("Cuisine - cannot be empty");
        }
    }
}
