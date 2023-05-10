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
        public DbSet<Character> Tbl_Character { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Piece>()
                .HasMany(e => e.Characters)
                .WithOne(e => e.piece)
                .HasForeignKey(e => e.IdPiece)
                .HasPrincipalKey(e => e.IdPiece);
        }

    }
}
