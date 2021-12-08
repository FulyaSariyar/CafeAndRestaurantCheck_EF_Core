using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeAndRestaurantCheck_EF_Core.Migrations
{
    public partial class BinaBilgiTblmasaadetgüncelleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MasaAdet",
                table: "BinaBilgileri",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BinaBilgileri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "BinaBilgileri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BinaBilgileri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "BinaBilgileri",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BinaBilgileri");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "BinaBilgileri");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BinaBilgileri");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "BinaBilgileri");

            migrationBuilder.AlterColumn<byte>(
                name: "MasaAdet",
                table: "BinaBilgileri",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
