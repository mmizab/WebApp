using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class storepointshistoryupdatee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorePointHistory_StorePoints_StorePointsId",
                table: "StorePointHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StorePointHistory",
                table: "StorePointHistory");

            migrationBuilder.RenameTable(
                name: "StorePointHistory",
                newName: "StorePointsHistory");

            migrationBuilder.RenameIndex(
                name: "IX_StorePointHistory_StorePointsId",
                table: "StorePointsHistory",
                newName: "IX_StorePointsHistory_StorePointsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StorePointsHistory",
                table: "StorePointsHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StorePointsHistory_StorePoints_StorePointsId",
                table: "StorePointsHistory",
                column: "StorePointsId",
                principalTable: "StorePoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorePointsHistory_StorePoints_StorePointsId",
                table: "StorePointsHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StorePointsHistory",
                table: "StorePointsHistory");

            migrationBuilder.RenameTable(
                name: "StorePointsHistory",
                newName: "StorePointHistory");

            migrationBuilder.RenameIndex(
                name: "IX_StorePointsHistory_StorePointsId",
                table: "StorePointHistory",
                newName: "IX_StorePointHistory_StorePointsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StorePointHistory",
                table: "StorePointHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StorePointHistory_StorePoints_StorePointsId",
                table: "StorePointHistory",
                column: "StorePointsId",
                principalTable: "StorePoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
