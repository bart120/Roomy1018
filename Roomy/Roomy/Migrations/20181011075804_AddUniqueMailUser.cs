using Microsoft.EntityFrameworkCore.Migrations;

namespace Roomy.Migrations
{
    public partial class AddUniqueMailUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_Mail",
                table: "Users",
                column: "Mail",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Mail",
                table: "Users");
        }
    }
}
