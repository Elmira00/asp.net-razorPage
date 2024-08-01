using asp.net_razorPage.Entities;
using asp.net_razorPage.Repositories;

namespace asp.net_razorPage.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;

        }
        public async Task AddAsync(Food food)
        {
            await _foodRepository.AddAsync(food);
        }

        public async Task DeleteAsync(int id)
        {
            Console.WriteLine($"Service: Deleting item with ID: {id}");
            await _foodRepository.DeleteAsync(id);
        }

        public async Task<List<Food>> GetAllAsync()
        {
            return await _foodRepository.GetAllAsync();
        }
        public async Task<Food> GetByIdAsync(int id)
        {
            return await _foodRepository.GetByIdAsync(id);
        }
        public async Task UpdateAsync(int id, Food updatedFood)
        {
            await _foodRepository.UpdateAsync(id, updatedFood);
        }
    }
}
