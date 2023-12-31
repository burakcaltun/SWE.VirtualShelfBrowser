using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWE.VirtualShelfBrowser.Migrations
{
    /// <inheritdoc />
    public partial class Lending : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "AppBooks");

            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "AppBooks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppBooks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppBooks",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AppBooks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPage",
                table: "AppBooks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhysicalLocation",
                table: "AppBooks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Lendings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lendings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lendings");

            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "AppBooks");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppBooks");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppBooks");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AppBooks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppBooks");

            migrationBuilder.DropColumn(
                name: "NumberOfPage",
                table: "AppBooks");

            migrationBuilder.DropColumn(
                name: "PhysicalLocation",
                table: "AppBooks");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "AppBooks",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
