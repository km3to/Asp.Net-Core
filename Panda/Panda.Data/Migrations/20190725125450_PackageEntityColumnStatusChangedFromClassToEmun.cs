using Microsoft.EntityFrameworkCore.Migrations;

namespace Panda.Data.Migrations
{
    public partial class PackageEntityColumnStatusChangedFromClassToEmun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackageStatus_PackageStatusId",
                table: "Packages");

            migrationBuilder.DropTable(
                name: "PackageStatus");

            migrationBuilder.DropIndex(
                name: "IX_Packages_PackageStatusId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "PackageStatusId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<int>(
                name: "PackageStatus",
                table: "Packages",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackageStatus",
                table: "Packages");

            migrationBuilder.AddColumn<string>(
                name: "PackageStatusId",
                table: "Packages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PackageStatus",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_PackageStatusId",
                table: "Packages",
                column: "PackageStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackageStatus_PackageStatusId",
                table: "Packages",
                column: "PackageStatusId",
                principalTable: "PackageStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
