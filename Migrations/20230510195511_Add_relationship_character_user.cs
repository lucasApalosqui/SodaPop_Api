using Microsoft.EntityFrameworkCore.Migrations;

namespace SodaPop.Migrations
{
    public partial class Add_relationship_character_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_piece",
                table: "Tbl_Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Character_id_piece",
                table: "Tbl_Character",
                column: "id_piece");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Character_Tbl_Piece_id_piece",
                table: "Tbl_Character",
                column: "id_piece",
                principalTable: "Tbl_Piece",
                principalColumn: "id_piece",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Character_Tbl_Piece_id_piece",
                table: "Tbl_Character");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Character_id_piece",
                table: "Tbl_Character");

            migrationBuilder.DropColumn(
                name: "id_piece",
                table: "Tbl_Character");
        }
    }
}
