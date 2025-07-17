using Microsoft.EntityFrameworkCore;

namespace Quizzler.Data
{
    public class DBContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
    }
}