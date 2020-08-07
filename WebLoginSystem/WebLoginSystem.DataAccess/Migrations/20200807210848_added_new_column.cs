using Microsoft.EntityFrameworkCore.Migrations;

namespace WebLoginSystem.DataAccess.Migrations
{
    public partial class added_new_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Userprofiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Userprofiles");
        }
    }
}
