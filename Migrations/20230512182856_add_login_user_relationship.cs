using Microsoft.EntityFrameworkCore.Migrations;

namespace SodaPop.Migrations
{
    public partial class add_login_user_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_login",
                table: "Tbl_User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_User_id_login",
                table: "Tbl_User",
                column: "id_login",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_User_Tbl_Login_id_login",
                table: "Tbl_User",
                column: "id_login",
                principalTable: "Tbl_Login",
                principalColumn: "id_login",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_User_Tbl_Login_id_login",
                table: "Tbl_User");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_User_id_login",
                table: "Tbl_User");

            migrationBuilder.DropColumn(
                name: "id_login",
                table: "Tbl_User");
        }
    }
}
