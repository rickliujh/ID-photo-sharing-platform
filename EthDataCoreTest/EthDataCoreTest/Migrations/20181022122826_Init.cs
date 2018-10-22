using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EthDataCoreTest.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "imageDataMaps",
                columns: table => new
                {
                    ImageName = table.Column<string>(nullable: false),
                    AccountAddress = table.Column<string>(nullable: false),
                    TransactionHash = table.Column<string>(nullable: false),
                    PublishTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imageDataMaps", x => x.ImageName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imageDataMaps");
        }
    }
}
