using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CraftDemo.Migrations
{
    /// <inheritdoc />
    public partial class MakingTheIdKeyFIeld : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GitHubUserInfo_Id",
                table: "GitHubUserInfo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GitHubUserInfo_Id",
                table: "GitHubUserInfo",
                column: "Id",
                unique: true);
        }
    }
}
