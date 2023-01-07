using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migblogremovescorecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_blogRaytings",
                table: "blogRaytings");

            migrationBuilder.DropColumn(
                name: "BlogScore",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "blogRaytings",
                newName: "BlogRaytings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogRaytings",
                table: "BlogRaytings",
                column: "BlogRaytingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogRaytings",
                table: "BlogRaytings");

            migrationBuilder.RenameTable(
                name: "BlogRaytings",
                newName: "blogRaytings");

            migrationBuilder.AddColumn<int>(
                name: "BlogScore",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_blogRaytings",
                table: "blogRaytings",
                column: "BlogRaytingID");
        }
    }
}
