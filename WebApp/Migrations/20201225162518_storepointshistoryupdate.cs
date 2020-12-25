using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class storepointshistoryupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreyPointHistory_StorePoints_StorePointsId",
                table: "StoreyPointHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreyPointHistory",
                table: "StoreyPointHistory");

            migrationBuilder.RenameTable(
                name: "StoreyPointHistory",
                newName: "StorePointHistory");

            migrationBuilder.RenameIndex(
                name: "IX_StoreyPointHistory_StorePointsId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorePointHistory_StorePoints_StorePointsId",
                table: "StorePointHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StorePointHistory",
                table: "StorePointHistory");

            migrationBuilder.RenameTable(
                name: "StorePointHistory",
                newName: "StoreyPointHistory");

            migrationBuilder.RenameIndex(
                name: "IX_StorePointHistory_StorePointsId",
                table: "StoreyPointHistory",
                newName: "IX_StoreyPointHistory_StorePointsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreyPointHistory",
                table: "StoreyPointHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreyPointHistory_StorePoints_StorePointsId",
                table: "StoreyPointHistory",
                column: "StorePointsId",
                principalTable: "StorePoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
