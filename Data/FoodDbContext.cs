using asp.net_razorPage.Entities;
using Microsoft.EntityFrameworkCore;

namespace asp.net_razorPage.Data
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options)
            : base(options)
        {

        }
        public DbSet<Food> Foods { get; set; }
    }
}
