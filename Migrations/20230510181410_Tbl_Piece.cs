using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SodaPop.Migrations
{
    public partial class Tbl_Piece : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Piece",
                columns: table => new
                {
                    id_piece = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    piece_name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    image_banner = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    image_front = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    average_score = table.Column<double>(type: "float", nullable: false),
                    description_piece = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    date_release = table.Column<DateTime>(type: "datetime2", nullable: false),
                    duration = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    director = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    producer = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Piece", x => x.id_piece);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Piece");
        }
    }
}
