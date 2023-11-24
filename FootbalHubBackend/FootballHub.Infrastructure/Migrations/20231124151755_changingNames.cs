using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootallHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changingNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Players",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "Players",
                newName: "FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Birth",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Players",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Players",
                newName: "Firstname");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Birth",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
