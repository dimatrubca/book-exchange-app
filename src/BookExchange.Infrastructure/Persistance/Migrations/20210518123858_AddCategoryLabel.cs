using Microsoft.EntityFrameworkCore.Migrations;

namespace BookExchange.Infrastructure.persistance.migrations
{
    public partial class AddCategoryLabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "BookCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "BookCategory");
        }
    }
}
