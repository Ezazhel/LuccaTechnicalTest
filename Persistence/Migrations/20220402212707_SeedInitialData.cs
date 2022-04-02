using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lucca.Persistence.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Currency_ISO = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Currency_ISO = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expense_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Currency_ISO", "LastName", "Name" },
                values: new object[] { new Guid("e66cc197-32d6-40f6-a588-53f05d6c0179"), "USD", "Stark", "Anthony" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Currency_ISO", "LastName", "Name" },
                values: new object[] { new Guid("b762682e-f1be-4163-848d-731d646b29e1"), "RUB", "Natasha ", "Romanova " });

            migrationBuilder.CreateIndex(
                name: "IX_Expense_UserId",
                table: "Expense",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
