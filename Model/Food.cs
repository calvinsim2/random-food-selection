using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RandomFoodSelection.Model
{
    [ExcludeFromCodeCoverage]
    public class Food
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Cuisine { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
