using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todoapp_api.Migrations
{
    public partial class RemoveStatusFromItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Item");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "#1A1A1A",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldDefaultValue: "#1A1A1A");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Item",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                defaultValue: "#1A1A1A",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "#1A1A1A");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Item",
                type: "int",
                nullable: true);
        }
    }
}
