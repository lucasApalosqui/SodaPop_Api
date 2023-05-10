using Microsoft.EntityFrameworkCore.Migrations;

namespace SodaPop.Migrations
{
    public partial class Add_relationship_table_UserPiece : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_User_Piece",
                columns: table => new
                {
                    PieceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_User_Piece", x => new { x.PieceId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Tbl_User_Piece_Tbl_Piece_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Tbl_Piece",
                        principalColumn: "id_piece",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_User_Piece_Tbl_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Tbl_User",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_User_Piece_UserId",
                table: "Tbl_User_Piece",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_User_Piece");
        }
    }
}
