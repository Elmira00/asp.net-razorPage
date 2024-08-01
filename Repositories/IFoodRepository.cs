using asp.net_razorPage.Entities;

namespace asp.net_razorPage.Repositories
{
    public interface IFoodRepository
    {
        Task AddAsync(Food food);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, Food updatedFood);
        Task<List<Food>> GetAllAsync();
        Task<Food> GetByIdAsync(int id);
    }
}
