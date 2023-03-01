using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Custom_Registration.CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class AddTestRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "Number", "PostCode", "Street" },
                values: new object[] { 1, "new asshole", "my ass", "FN", "550272", "Death" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "InvoiceAddressId", "Name", "PhoneNumber", "PostalAddressId", "Website" },
                values: new object[] { 1, "ema.g@gmail.com", 1, "AN", "1234567890", 1, "www.ne.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customers");
        }
    }
}
