using Domain.Entities;
using Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class MySqlContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optBuilder)
        {
            if (!optBuilder.IsConfigured)
                optBuilder.UseMySql("server=127.0.0.1;port=3306;database=ddd_crud;user=root;password=password");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
        }

    }
}
