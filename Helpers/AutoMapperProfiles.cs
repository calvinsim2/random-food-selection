using AutoMapper;
using RandomFoodSelection.Dto;
using RandomFoodSelection.Model;

namespace RandomFoodSelection.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<FoodDto, Food>();
            CreateMap<Food, FoodDto>();
        }
    }
}
