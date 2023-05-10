using Microsoft.EntityFrameworkCore;
using SodaPop.Models;

namespace SodaPop.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Tbl_User { get; set; }
        public DbSet<Piece> Tbl_Piece { get; set; }
    }
}
