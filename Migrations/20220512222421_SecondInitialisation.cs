using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourDuSoirBackEnd.Migrations
{
    public partial class SecondInitialisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "numberOfLearners",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numberOfLearners",
                table: "Groups");
        }
    }
}
