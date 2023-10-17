using RandomFoodSelection.Interfaces.Repositories;
using RandomFoodSelection.Interfaces.Services;
using RandomFoodSelection.Model;

namespace RandomFoodSelection.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<List<Food>> GetAllFoodAsync()
        {
            return await _foodRepository.GetAllAsync();
        }

        public async Task<Food?> GetFoodByIdAsync(Guid id)
        {
            return await _foodRepository.GetByIdAsync(id);
        }
        public async Task AddFoodAsync(Food food) 
        {
            await _foodRepository.AddAsync(food);
            await _foodRepository.SaveChangesAsync();
        }
        public async Task UpdateFoodAsync(Food food)
        {
            var existingFood = await _foodRepository.GetByIdAsync(food.Id);
            if (existingFood is null)
            {
                return;
            }

            existingFood.Name = food.Name;
            existingFood.Cuisine = food.Cuisine;
            existingFood.Image = food.Image;
            existingFood.Location = food.Location;

            _foodRepository.Update(existingFood);
            await _foodRepository.SaveChangesAsync();
        }
        public async Task DeleteFoodAsync(Guid id)
        {
            var existingFood = await _foodRepository.GetByIdAsync(id);
            if (existingFood is null)
            {
                return;
            }

            _foodRepository.Remove(existingFood);
            await _foodRepository.SaveChangesAsync();
        }
    }
}
