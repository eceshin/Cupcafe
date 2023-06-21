using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cupcafe.Migrations
{
    /// <inheritdoc />
    public partial class Cafe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IslemId",
                table: "KullaniciUrunler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Islemler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IslemAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Islemler", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciUrunler_IslemId",
                table: "KullaniciUrunler",
                column: "IslemId");

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciUrunler_Islemler_IslemId",
                table: "KullaniciUrunler",
                column: "IslemId",
                principalTable: "Islemler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciUrunler_Islemler_IslemId",
                table: "KullaniciUrunler");

            migrationBuilder.DropTable(
                name: "Islemler");

            migrationBuilder.DropIndex(
                name: "IX_KullaniciUrunler_IslemId",
                table: "KullaniciUrunler");

            migrationBuilder.DropColumn(
                name: "IslemId",
                table: "KullaniciUrunler");
        }
    }
}
