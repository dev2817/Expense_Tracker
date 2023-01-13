using expense_tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace expense_tracker
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Global> Global { get; set; }
    }
}
