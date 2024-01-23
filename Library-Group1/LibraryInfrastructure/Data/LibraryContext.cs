using Library.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Domain> Domains { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().UseTpcMappingStrategy();
            modelBuilder.Entity<Reader>().ToTable("Readers");
            modelBuilder.Entity<Writer>().ToTable("Writers");
            modelBuilder.Entity<Admin>().ToTable("Admins");
        }
    }
}
