using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContentManagementSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPost_Posts_OrdersId",
                table: "CategoryPost");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "CategoryPost",
                newName: "PostsId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryPost_OrdersId",
                table: "CategoryPost",
                newName: "IX_CategoryPost_PostsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPost_Posts_PostsId",
                table: "CategoryPost",
                column: "PostsId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPost_Posts_PostsId",
                table: "CategoryPost");

            migrationBuilder.RenameColumn(
                name: "PostsId",
                table: "CategoryPost",
                newName: "OrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryPost_PostsId",
                table: "CategoryPost",
                newName: "IX_CategoryPost_OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPost_Posts_OrdersId",
                table: "CategoryPost",
                column: "OrdersId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
