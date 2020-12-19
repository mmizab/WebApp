using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class linkstorepost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Post",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_StoreId",
                table: "Post",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Store_StoreId",
                table: "Post",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Store_StoreId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_StoreId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Post");
        }
    }
}
