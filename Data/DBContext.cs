using Microsoft.EntityFrameworkCore;
using Quizzler.Models;

namespace Quizzler.Data
{
    public class DBContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasDiscriminator<string>("type")
                .HasValue<OpenQuestion>("Open")
                .HasValue<MultipleChoiceQuestion>("MultipleChoice")
                .HasValue<BinaryQuestion>("Binary")
                .HasValue<NumericQuestion>("Numeric");
        }
    }
}