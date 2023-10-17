using System.Diagnostics.CodeAnalysis;

namespace RandomFoodSelection.Dto
{
    [ExcludeFromCodeCoverage]
    public class FoodDto
    {
        public string Name { get; set; } = string.Empty;
        public string Cuisine { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
