using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class operation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opartaion",
                table: "StoreyPointHistory");

            migrationBuilder.AddColumn<string>(
                name: "Operation",
                table: "StoreyPointHistory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operation",
                table: "StoreyPointHistory");

            migrationBuilder.AddColumn<string>(
                name: "Opartaion",
                table: "StoreyPointHistory",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
