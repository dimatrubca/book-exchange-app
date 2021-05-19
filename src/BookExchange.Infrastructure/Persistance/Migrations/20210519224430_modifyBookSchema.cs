using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookExchange.Infrastructure.persistance.migrations
{
    public partial class modifyBookSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishedOn",
                table: "BookDetails");

            migrationBuilder.AddColumn<int>(
                name: "PublishedYear",
                table: "BookDetails",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishedYear",
                table: "BookDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedOn",
                table: "BookDetails",
                type: "datetime2",
                nullable: true);
        }
    }
}
