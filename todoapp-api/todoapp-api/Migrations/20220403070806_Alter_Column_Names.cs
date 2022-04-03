using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todoapp_api.Migrations
{
    public partial class Alter_Column_Names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemFK",
                table: "SubItem",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "UserFK",
                table: "Item",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "SubItem",
                newName: "ItemFK");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Item",
                newName: "UserFK");
        }
    }
}
