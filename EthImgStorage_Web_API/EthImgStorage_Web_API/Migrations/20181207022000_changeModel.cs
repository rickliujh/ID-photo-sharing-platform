using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EthImgStorage_Web_API.Migrations
{
    public partial class changeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "indexs",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    AccountAddress = table.Column<string>(nullable: true),
                    TransationHash = table.Column<string>(nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_indexs", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "indexs");
        }
    }
}
