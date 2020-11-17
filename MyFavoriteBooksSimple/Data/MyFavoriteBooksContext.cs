using Microsoft.EntityFrameworkCore;
using MyFavoriteBooksSimple.Models;
using System;

namespace MyFavoriteBooksSimple.Data
{
    public class MyFavoriteBooksContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public MyFavoriteBooksContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            optionsBuilder.UseSqlite($@"Data Source={userPath}/{nameof(MyFavoriteBooksContext)}.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author { Id = 1, FirstName = "Eric", LastName = "Evans" });
            modelBuilder.Entity<Author>().HasData(new Author { Id = 2, FirstName = "Bruno", LastName = "Preiss" });
            modelBuilder.Entity<Author>().HasData(new Author { Id = 3, FirstName = "Kenneth", LastName = "Rubin" });
            modelBuilder.Entity<Author>().HasData(new Author { Id = 4, FirstName = "Robert", LastName = "Martin" });
        }
    }
}
