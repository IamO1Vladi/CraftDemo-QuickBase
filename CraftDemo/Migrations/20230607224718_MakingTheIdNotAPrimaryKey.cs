using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CraftDemo.Migrations
{
    /// <inheritdoc />
    public partial class MakingTheIdNotAPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GitHubUserInfo_Id",
                table: "GitHubUserInfo",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GitHubUserInfo_Id",
                table: "GitHubUserInfo");
        }
    }
}
