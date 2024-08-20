using BookReservesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReservesAPI.Data
{
    public class BookContext: DbContext
    {
        public readonly IConfiguration _config;
        public BookContext(IConfiguration config) 
        { 
            _config = config;
        }
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(_config.GetConnectionString("DefaultConnection"),
                        optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }
        }
    }
}
