using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBooks1.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookItem>().ToTable("BookView");
            //modelBuilder.Entity<BookItem>().ToTable("Book");
            modelBuilder.Entity<User>().ToTable("User");
        }

        public DbSet<BookItem> BookItems { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
