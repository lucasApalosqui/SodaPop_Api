using Microsoft.EntityFrameworkCore.Migrations;

namespace SodaPop.Migrations
{
    public partial class add_pieceTypeColumn_TblPiece : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "piece_type",
                table: "Tbl_Piece",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "piece_type",
                table: "Tbl_Piece");
        }
    }
}
