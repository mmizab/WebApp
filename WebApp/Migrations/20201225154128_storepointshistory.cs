using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class storepointshistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoreyPointHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Opartaion = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    StorePointsId = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreyPointHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreyPointHistory_StorePoints_StorePointsId",
                        column: x => x.StorePointsId,
                        principalTable: "StorePoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreyPointHistory_StorePointsId",
                table: "StoreyPointHistory",
                column: "StorePointsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreyPointHistory");
        }
    }
}
