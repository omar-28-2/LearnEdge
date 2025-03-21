using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Contexts
{
    public class LearnEdge : DbContext
    {
        public LearnEdge(DbContextOptions<LearnEdge> options) : base(options)
        {
            
        }
        public DbSet<BaseEntity> BaseEntities { get; set; } 
    }
}
