using Microsoft.EntityFrameworkCore.Migrations;

namespace WebLoginSystem.DataAccess.Migrations
{
    public partial class remove_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Userprofiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Userprofiles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
