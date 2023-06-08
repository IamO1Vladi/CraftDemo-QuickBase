using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CraftDemo.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserNameToNonUnicode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "GitHubUserInfo",
                type: "varchar(39)",
                unicode: false,
                maxLength: 39,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(39)",
                oldMaxLength: 39);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "GitHubUserInfo",
                type: "nvarchar(39)",
                maxLength: 39,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(39)",
                oldUnicode: false,
                oldMaxLength: 39);
        }
    }
}
