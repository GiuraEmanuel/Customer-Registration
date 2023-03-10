// <auto-generated />
using Custom_Registration.CodeFirst;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Custom_Registration.CodeFirst.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Custom_Registration.CodeFirst.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Sibiu",
                            Country = "Romania",
                            Number = "FN",
                            PostCode = "550272",
                            Street = "Florilor"
                        },
                        new
                        {
                            Id = 2,
                            City = "New York",
                            Country = "USA",
                            Number = "15",
                            PostCode = "550171",
                            Street = "Heroes Street"
                        });
                });

            modelBuilder.Entity("Custom_Registration.CodeFirst.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvoiceAddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalAddressId")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceAddressId")
                        .IsUnique();

                    b.HasIndex("PostalAddressId")
                        .IsUnique();

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "g.e@gmail.com",
                            InvoiceAddressId = 1,
                            Name = "Giura Emanuel",
                            PhoneNumber = "1234567890",
                            PostalAddressId = 1,
                            Website = "www.ge.com"
                        },
                        new
                        {
                            Id = 2,
                            Email = "a.j@g@gmail.com",
                            InvoiceAddressId = 2,
                            Name = "Adam Jensen",
                            PhoneNumber = "555-555-555",
                            PostalAddressId = 2,
                            Website = "www.aj.com"
                        });
                });

            modelBuilder.Entity("Custom_Registration.CodeFirst.Customer", b =>
                {
                    b.HasOne("Custom_Registration.CodeFirst.Address", "InvoiceAddress")
                        .WithOne()
                        .HasForeignKey("Custom_Registration.CodeFirst.Customer", "InvoiceAddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Custom_Registration.CodeFirst.Address", "PostalAddress")
                        .WithOne()
                        .HasForeignKey("Custom_Registration.CodeFirst.Customer", "PostalAddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("InvoiceAddress");

                    b.Navigation("PostalAddress");
                });
#pragma warning restore 612, 618
        }
    }
}
