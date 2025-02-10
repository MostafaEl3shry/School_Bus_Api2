using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Bus_Api.Migrations
{
    /// <inheritdoc />
    public partial class SchoolBus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "buses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusCode = table.Column<int>(type: "int", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "registrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    studentPhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    studentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    confirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parentName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    parentPhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registrations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverCode = table.Column<int>(type: "int", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DriverPhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DriverAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DriverID = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    BusCode = table.Column<int>(type: "int", nullable: false),
                    busModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_drivers_buses_busModelId",
                        column: x => x.busModelId,
                        principalTable: "buses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_buses_BusCode",
                table: "buses",
                column: "BusCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_drivers_busModelId",
                table: "drivers",
                column: "busModelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_drivers_DriverCode",
                table: "drivers",
                column: "DriverCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_drivers_DriverPhoneNumber",
                table: "drivers",
                column: "DriverPhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_registrations_parentPhoneNumber",
                table: "registrations",
                column: "parentPhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_registrations_studentPhoneNumber",
                table: "registrations",
                column: "studentPhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "drivers");

            migrationBuilder.DropTable(
                name: "registrations");

            migrationBuilder.DropTable(
                name: "buses");
        }
    }
}
