using RandomFoodSelection.Model;

namespace RandomFoodSelection.Interfaces.Repositories
{
    public interface IFoodRepository
    {
        Task<List<Food>> GetAllAsync();
        Task<Food?> GetByIdAsync(Guid id);
        Task AddAsync(Food food);
        void Update(Food food);
        void Remove(Food food);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
