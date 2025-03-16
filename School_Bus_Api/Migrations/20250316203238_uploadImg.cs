using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Bus_Api.Migrations
{
    /// <inheritdoc />
    public partial class uploadImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DriverImg",
                table: "drivers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverImg",
                table: "drivers");
        }
    }
}
