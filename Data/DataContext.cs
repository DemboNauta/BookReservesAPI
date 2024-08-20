using BookReservesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReservesAPI.Data
{
    public class DataContext : DbContext
    {
        public readonly IConfiguration _config;
        public DataContext(IConfiguration config)
        {
            _config = config;
        }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Author> Authors { get; set; }


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
