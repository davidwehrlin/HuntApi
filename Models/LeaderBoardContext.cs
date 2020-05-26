using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace hunt_api.Models
{
    public class LeaderBoardContext: DbContext
    {
        public LeaderBoardContext(DbContextOptions<LeaderBoardContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}