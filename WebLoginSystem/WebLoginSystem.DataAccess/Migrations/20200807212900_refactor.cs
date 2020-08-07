using Microsoft.EntityFrameworkCore.Migrations;

namespace WebLoginSystem.DataAccess.Migrations
{
    public partial class refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Userprofiles");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Userprofiles");

            migrationBuilder.AddColumn<int>(
                name: "UserCredentailId",
                table: "Userprofiles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserCredentails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCredentails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Userprofiles_UserCredentailId",
                table: "Userprofiles",
                column: "UserCredentailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Userprofiles_UserCredentails_UserCredentailId",
                table: "Userprofiles",
                column: "UserCredentailId",
                principalTable: "UserCredentails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Userprofiles_UserCredentails_UserCredentailId",
                table: "Userprofiles");

            migrationBuilder.DropTable(
                name: "UserCredentails");

            migrationBuilder.DropIndex(
                name: "IX_Userprofiles_UserCredentailId",
                table: "Userprofiles");

            migrationBuilder.DropColumn(
                name: "UserCredentailId",
                table: "Userprofiles");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Userprofiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Userprofiles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
