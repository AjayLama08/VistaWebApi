using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vista.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryCode = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    CategoryName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryCode);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    TrainerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.TrainerId);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrainerId = table.Column<int>(type: "INTEGER", nullable: false),
                    SessionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BookingReference = table.Column<string>(type: "TEXT", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_Sessions_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainerCategories",
                columns: table => new
                {
                    TrainerId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryCode = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerCategories", x => new { x.TrainerId, x.CategoryCode });
                    table.ForeignKey(
                        name: "FK_TrainerCategories_Categories_CategoryCode",
                        column: x => x.CategoryCode,
                        principalTable: "Categories",
                        principalColumn: "CategoryCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainerCategories_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryCode", "CategoryName" },
                values: new object[,]
                {
                    { "ED", "Equality and Diversity" },
                    { "HS", "Health and Safety" },
                    { "IT", "Information Technology" },
                    { "LM", "Leadership and Management" },
                    { "MAR", "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "TrainerId", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Middlesbrough", "Palmer Patel" },
                    { 2, "Stockton-on-Tees", "Cater Moon" },
                    { 3, "Middlesbrough", "Alex Dickerson" },
                    { 4, "Stockton-on-Tees", "Sally Johnson" }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "SessionId", "BookingReference", "SessionDate", "TrainerId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, null, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, null, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, null, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, "TST-99", new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, null, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, null, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, null, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, null, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, null, new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, null, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, null, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, null, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, null, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, null, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, "TST-98", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, "TST-97", new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, null, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, null, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, null, new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, null, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 22, null, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 23, null, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 24, "TST-96", new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 25, null, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 26, null, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 27, null, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 28, null, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 29, null, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 30, "TST-94", new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 31, null, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 32, null, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 33, "TST-95", new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 34, null, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 35, null, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 36, null, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });

            migrationBuilder.InsertData(
                table: "TrainerCategories",
                columns: new[] { "CategoryCode", "TrainerId" },
                values: new object[,]
                {
                    { "ED", 1 },
                    { "IT", 1 },
                    { "ED", 2 },
                    { "HS", 2 },
                    { "LM", 2 },
                    { "IT", 3 },
                    { "LM", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_TrainerId",
                table: "Sessions",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerCategories_CategoryCode",
                table: "TrainerCategories",
                column: "CategoryCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "TrainerCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Trainers");
        }
    }
}
