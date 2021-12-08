using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeAndRestaurantCheck_EF_Core.Migrations
{
    public partial class UrunFotograf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Fotograf",
                table: "Urunler",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fotograf",
                table: "Urunler");
        }
    }
}
