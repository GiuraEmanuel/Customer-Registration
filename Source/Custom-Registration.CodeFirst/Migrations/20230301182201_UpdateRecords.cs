using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Custom_Registration.CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Country", "Street" },
                values: new object[] { "Sibiu", "Romania", "Florilor" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "Number", "PostCode", "Street" },
                values: new object[] { 2, "New York", "USA", "15", "550171", "Heroes Street" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name", "Website" },
                values: new object[] { "g.e@gmail.com", "Giura Emanuel", "www.ge.com" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "InvoiceAddressId", "Name", "PhoneNumber", "PostalAddressId", "Website" },
                values: new object[] { 2, "a.j@g@gmail.com", 2, "Adam Jensen", "555-555-555", 2, "www.aj.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Country", "Street" },
                values: new object[] { "new asshole", "my ass", "Death" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name", "Website" },
                values: new object[] { "ema.g@gmail.com", "AN", "www.ne.com" });
        }
    }
}
