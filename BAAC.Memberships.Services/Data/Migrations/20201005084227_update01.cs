using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BAAC.Memberships.Services.Data.Migrations {
  public partial class update01 : Migration {
    protected override void Up(MigrationBuilder migrationBuilder) {
      migrationBuilder.CreateTable(
          name: "Members",
          columns: table => new {
            Id = table.Column<Guid>(nullable: false),
            Nickname = table.Column<string>(maxLength: 50, nullable: true),
            CreatedDate = table.Column<DateTime>(nullable: false),
            LastLoginDate = table.Column<DateTime>(nullable: true),
            Note = table.Column<string>(nullable: true)
          },
          constraints: table => {
            table.PrimaryKey("PK_Members", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Packages",
          columns: table => new {
            Code = table.Column<string>(nullable: false),
            Name = table.Column<string>(maxLength: 50, nullable: false),
            Days = table.Column<int>(nullable: false),
            Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
          },
          constraints: table => {
            table.PrimaryKey("PK_Packages", x => x.Code);
          });

      migrationBuilder.CreateTable(
          name: "Subscriptions",
          columns: table => new {
            Id = table.Column<Guid>(nullable: false),
            Date = table.Column<DateTime>(nullable: false),
            OwnerId = table.Column<Guid>(nullable: false),
            PackageCode = table.Column<string>(nullable: false)
          },
          constraints: table => {
            table.PrimaryKey("PK_Subscriptions", x => x.Id);
            table.ForeignKey(
                      name: "FK_Subscriptions_Members_OwnerId",
                      column: x => x.OwnerId,
                      principalTable: "Members",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Subscriptions_Packages_PackageCode",
                      column: x => x.PackageCode,
                      principalTable: "Packages",
                      principalColumn: "Code",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateIndex(
          name: "IX_Subscriptions_OwnerId",
          table: "Subscriptions",
          column: "OwnerId");

      migrationBuilder.CreateIndex(
          name: "IX_Subscriptions_PackageCode",
          table: "Subscriptions",
          column: "PackageCode");
    }

    protected override void Down(MigrationBuilder migrationBuilder) {
      migrationBuilder.DropTable(
          name: "Subscriptions");

      migrationBuilder.DropTable(
          name: "Members");

      migrationBuilder.DropTable(
          name: "Packages");
    }
  }
}
