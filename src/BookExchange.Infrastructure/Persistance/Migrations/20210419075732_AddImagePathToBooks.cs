using Microsoft.EntityFrameworkCore.Migrations;

namespace BookExchange.Infrastructure.persistance.migrations
{
    public partial class AddImagePathToBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxLendingPeriod",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailPath",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "BookDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailPath",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "BookDetails");

            migrationBuilder.AddColumn<int>(
                name: "MaxLendingPeriod",
                table: "Posts",
                type: "int",
                nullable: true);
        }
    }
}
