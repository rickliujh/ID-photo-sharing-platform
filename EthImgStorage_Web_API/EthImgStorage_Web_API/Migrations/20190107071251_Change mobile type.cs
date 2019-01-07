using Microsoft.EntityFrameworkCore.Migrations;

namespace EthImgStorage_Web_API.Migrations
{
    public partial class Changemobiletype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Mobile",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Mobile",
                table: "Users",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
