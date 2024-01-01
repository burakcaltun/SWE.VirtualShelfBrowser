using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWE.VirtualShelfBrowser.Migrations
{
    /// <inheritdoc />
    public partial class burak2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Lendings",
                table: "Lendings");

            migrationBuilder.RenameTable(
                name: "Lendings",
                newName: "AppLendings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppLendings",
                table: "AppLendings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppLendings_BookId",
                table: "AppLendings",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppLendings_AppBooks_BookId",
                table: "AppLendings",
                column: "BookId",
                principalTable: "AppBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppLendings_AppBooks_BookId",
                table: "AppLendings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppLendings",
                table: "AppLendings");

            migrationBuilder.DropIndex(
                name: "IX_AppLendings_BookId",
                table: "AppLendings");

            migrationBuilder.RenameTable(
                name: "AppLendings",
                newName: "Lendings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lendings",
                table: "Lendings",
                column: "Id");
        }
    }
}
