using IMDBDataStore.Schema.Models;
using Microsoft.EntityFrameworkCore;

namespace IMDBDataStore.Schema.Context
{
    public class IMDBContext : DbContext
    {
        public IMDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<RolesInfo> RolesInfo { get; set; }
    }
}
