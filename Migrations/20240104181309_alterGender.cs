using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace renatomoviestore.Migrations
{
    /// <inheritdoc />
    public partial class alterGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genero",
                table: "Customers",
                newName: "Gender");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Customers",
                newName: "Genero");
        }
    }
}
