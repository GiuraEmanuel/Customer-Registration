using Microsoft.EntityFrameworkCore;

namespace Custom_Registration.CodeFirst
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<Address> Addresses => Set<Address>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .HasOne(e => e.PostalAddress)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Customer>()
                .HasOne(e => e.InvoiceAddress)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    Street = "Florilor",
                    Number = "FN",
                    PostCode = "550272",
                    City = "Sibiu",
                    Country = "Romania",
                });

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Giura Emanuel",
                    Website = "www.ge.com",
                    Email = "g.e@gmail.com",
                    PhoneNumber = "1234567890",
                    PostalAddressId = 1,
                    InvoiceAddressId = 1
                });


            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 2,
                    Street = "Heroes Street",
                    Number = "15",
                    PostCode = "550171",
                    City = "New York",
                    Country = "USA",
                });

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 2,
                    Name = "Adam Jensen",
                    Website = "www.aj.com",
                    Email = "a.j@g@gmail.com",
                    PhoneNumber = "555-555-555",
                    PostalAddressId = 2,
                    InvoiceAddressId = 2
                });
        }
    }
}
