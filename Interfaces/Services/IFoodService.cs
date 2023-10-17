using RandomFoodSelection.Model;

namespace RandomFoodSelection.Interfaces.Services
{
    public interface IFoodService
    {
        Task<List<Food>> GetAllFoodAsync();
        Task<Food?> GetFoodByIdAsync(Guid id);
        Task AddFoodAsync(Food food);
        Task UpdateFoodAsync(Food food);
        Task DeleteFoodAsync(Guid id);
    }
}
