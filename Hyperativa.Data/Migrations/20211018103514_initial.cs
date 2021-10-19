using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hyperativa.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HPRTV_Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identifier = table.Column<string>(type: "varchar(2)", nullable: false),
                    Lote = table.Column<string>(type: "varchar(8)", nullable: false),
                    CardNumber = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HPRTV_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HPRTV_Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "varchar(200)", nullable: false),
                    Password = table.Column<string>(type: "varchar(200)", nullable: false),
                    Access = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HPRTV_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HPRTV_Cards");

            migrationBuilder.DropTable(
                name: "HPRTV_Users");
        }
    }
}
