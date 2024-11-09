using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vista.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "Workshops",
                columns: table => new
                {
                    WorkshopId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CategoryCode = table.Column<string>(type: "TEXT", nullable: false),
                    BookingRef = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshops", x => x.WorkshopId);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopStaff",
                columns: table => new
                {
                    WorkshopId = table.Column<int>(type: "INTEGER", nullable: false),
                    StaffId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopStaff", x => new { x.WorkshopId, x.StaffId });
                    table.ForeignKey(
                        name: "FK_WorkshopStaff_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkshopStaff_Workshops_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "WorkshopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "StaffId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Shripati", "MacGrory" },
                    { 2, "Nani", "Martinsson" },
                    { 3, "Harrison", "Presley" },
                    { 4, "Theo", "Orr" },
                    { 5, "Drew", "Metcalfe" }
                });

            migrationBuilder.InsertData(
                table: "Workshops",
                columns: new[] { "WorkshopId", "BookingRef", "CategoryCode", "DateAndTime", "Name" },
                values: new object[,]
                {
                    { 1, null, "", new DateTime(2023, 1, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), "Excel (Beginner)" },
                    { 2, null, "", new DateTime(2023, 1, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), "Excel (Intermediate)" },
                    { 3, null, "", new DateTime(2023, 9, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Word (Beginner)" }
                });

            migrationBuilder.InsertData(
                table: "WorkshopStaff",
                columns: new[] { "StaffId", "WorkshopId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 4, 2 },
                    { 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopStaff_StaffId",
                table: "WorkshopStaff",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkshopStaff");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Workshops");
        }
    }
}
