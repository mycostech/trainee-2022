using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todoapp_api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_User_Item = table.Column<int>(type: "int", nullable: false),
                    UserFK = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true, defaultValue: 5),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, defaultValue: "#1A1A1A"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LimitedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_User_FK_User_Item",
                        column: x => x.FK_User_Item,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_Item_SubItem = table.Column<int>(type: "int", nullable: false),
                    ItemFK = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubItem_Item_FK_Item_SubItem",
                        column: x => x.FK_Item_SubItem,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_FK_User_Item",
                table: "Item",
                column: "FK_User_Item");

            migrationBuilder.CreateIndex(
                name: "IX_SubItem_FK_Item_SubItem",
                table: "SubItem",
                column: "FK_Item_SubItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubItem");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
