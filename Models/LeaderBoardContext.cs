using Microsoft.EntityFrameworkCore;

namespace hunt_api.Models
{
    public class LeaderBoardContext : DbContext
    {
        public LeaderBoardContext(DbContextOptions<LeaderBoardContext> options)
            : base(options)
        {
        }

        public DbSet<Item> items { get; set; }
    }
}