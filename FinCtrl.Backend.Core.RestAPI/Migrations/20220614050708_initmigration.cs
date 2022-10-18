using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinCtrl.Backend.Core.RestAPI.Migrations
{
    public partial class initmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentSources",
                columns: table => new
                {
                    PaymentSourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentSourceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSources", x => x.PaymentSourceId);
                    table.ForeignKey(
                        name: "FK_PaymentSources_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    PaymentSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentSourceId = table.Column<int>(type: "int", nullable: false),
                    PaymentCategoryCategoryId = table.Column<int>(type: "int", nullable: true),
                    PaymentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Categories_PaymentCategoryCategoryId",
                        column: x => x.PaymentCategoryCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_Payments_PaymentSources_PaymentSourceId",
                        column: x => x.PaymentSourceId,
                        principalTable: "PaymentSources",
                        principalColumn: "PaymentSourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentCategoryCategoryId",
                table: "Payments",
                column: "PaymentCategoryCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentSourceId",
                table: "Payments",
                column: "PaymentSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSources_CategoryId",
                table: "PaymentSources",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PaymentSources");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
