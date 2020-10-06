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
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Packages",
                nullable: false,
                defaultValue: 0);
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
