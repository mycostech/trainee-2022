using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todoapp_api.Migrations
{
    public partial class ChangeTypeOfPriorityToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "5",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "Item",
                type: "int",
                nullable: true,
                defaultValue: 5,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "5");
        }
    }
}
