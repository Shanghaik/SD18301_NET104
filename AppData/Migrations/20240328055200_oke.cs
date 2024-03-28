using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    public partial class oke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HoaDon",
                table: "HoaDon");

            migrationBuilder.RenameTable(
                name: "HoaDon",
                newName: "HoaDons");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDon_UserID",
                table: "HoaDons",
                newName: "IX_HoaDons_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HoaDons",
                table: "HoaDons",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HoaDons",
                table: "HoaDons");

            migrationBuilder.RenameTable(
                name: "HoaDons",
                newName: "HoaDon");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDons_UserID",
                table: "HoaDon",
                newName: "IX_HoaDon_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HoaDon",
                table: "HoaDon",
                column: "Id");
        }
    }
}
