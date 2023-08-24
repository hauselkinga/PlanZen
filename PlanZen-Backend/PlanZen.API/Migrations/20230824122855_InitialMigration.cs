using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanZen.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Columns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Columns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Columns_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    DueDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    ColumnId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Columns_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "Columns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "Pet Project" });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "Todos" });

            migrationBuilder.InsertData(
                table: "Columns",
                columns: new[] { "Id", "TableId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "ToDo" },
                    { 2, 1, "InProgress" },
                    { 3, 2, "Todos" },
                    { 4, 2, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "ColumnId", "CreatedDate", "Description", "DueDate", "Title" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(2023, 8, 24, 14, 28, 55, 204, DateTimeKind.Unspecified).AddTicks(5867), new TimeSpan(0, 2, 0, 0, 0)), "Implement... Implement everything", null, "Implement Project" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "ColumnId", "CreatedDate", "Description", "DueDate", "Title" },
                values: new object[] { 2, 2, new DateTimeOffset(new DateTime(2023, 8, 24, 14, 28, 55, 204, DateTimeKind.Unspecified).AddTicks(5915), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Plan Project" });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ColumnId",
                table: "Cards",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_Columns_TableId",
                table: "Columns",
                column: "TableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Columns");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
