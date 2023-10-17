using RandomFoodSelection.Context;
using RandomFoodSelection.Interfaces.Repositories;
using RandomFoodSelection.Model;
using Microsoft.EntityFrameworkCore;

namespace RandomFoodSelection.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly FoodContext _foodContext;

        public FoodRepository(FoodContext foodContext)
        {
            _foodContext = foodContext;
        }

        public async Task<List<Food>> GetAllAsync()
        {
            return await _foodContext.Food.ToListAsync();
        }

        public async Task<Food?> GetByIdAsync(Guid id)
        {
            return await _foodContext.Food.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Food food)
        {
            await _foodContext.Food.AddAsync(food);
        }
        public void Update(Food food)
        {
            _foodContext.Food.Update(food);
        }
        public void Remove(Food food)
        {
            _foodContext.Food.Remove(food);
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _foodContext.SaveChangesAsync(cancellationToken);
        }
    }
}
