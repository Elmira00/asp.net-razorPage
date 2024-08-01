using asp.net_razorPage.Data;
using asp.net_razorPage.Entities;
using Microsoft.EntityFrameworkCore;

namespace asp.net_razorPage.Repositories
{
    public class EFFoodRepository : IFoodRepository
    {
        private readonly FoodDbContext _context;
        public EFFoodRepository(FoodDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Food food)
        {
            await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();
        }
        public async Task<Food> GetByIdAsync(int id)
        {
            return await _context.Foods.SingleOrDefaultAsync(f => f.Id == id);
        }
        public async Task DeleteAsync(int id)
        {
            var food = await _context.Foods.SingleOrDefaultAsync(e => e.Id == id);
            if (food != null)
            {
                _context.Foods.Remove(food);
                await _context.SaveChangesAsync();
                Console.WriteLine($"Repository: Deleted item with ID: {id}");
            }
        }


        public async Task<List<Food>> GetAllAsync()
        {
            return await _context.Foods.ToListAsync();
        }

        public async Task UpdateAsync(int id, Food updatedFood)
        {
            var food = await _context.Foods.FindAsync(id);

            if (food == null)
            {
                throw new Exception("Food not found");
            }

            food.Name = updatedFood.Name;
            food.Description = updatedFood.Description;
            food.Price = updatedFood.Price;
            food.ImagePath = updatedFood.ImagePath;

            _context.Entry(food).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
