using Microsoft.EntityFrameworkCore.Migrations;

namespace SodaPop.Migrations
{
    public partial class Add_TblCharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Character",
                columns: table => new
                {
                    id_character = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_character = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    character_name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Character", x => x.id_character);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Character");
        }
    }
}
