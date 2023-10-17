using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RandomFoodSelection.Model;

namespace RandomFoodSelection.EntityConfiguration
{
    public class FoodEntityConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.Property(o => o.Name)
                .IsRequired(true);

            builder.Property(o => o.Cuisine)
                .IsRequired(true);

            builder.Property(o => o.Image)
                .IsRequired(false);

            builder.Property(o => o.Location)
                .IsRequired(false);
        }
    }
}
