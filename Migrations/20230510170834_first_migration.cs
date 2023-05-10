using Microsoft.EntityFrameworkCore.Migrations;

namespace SodaPop.Migrations
{
    public partial class first_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_User",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    title_user = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    description_user = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    avatar_user = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    banner_user = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    average_user_score = table.Column<double>(type: "float", nullable: false),
                    favorite_piece = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    worst_piece = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    hated_character = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    lovely_character = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_User", x => x.id_user);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_User");
        }
    }
}
