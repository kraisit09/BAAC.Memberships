using Microsoft.EntityFrameworkCore.Migrations;

namespace BAAC.Memberships.Services.Data.Migrations
{
    public partial class update03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PaidAmount",
                table: "Subscriptions",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Packages",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidAmount",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Packages");
        }
    }
}
