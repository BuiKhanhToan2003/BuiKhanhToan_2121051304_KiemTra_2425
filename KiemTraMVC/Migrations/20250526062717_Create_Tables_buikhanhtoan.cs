using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KiemTraMVC.Migrations
{
    /// <inheritdoc />
    public partial class Create_Tables_buikhanhtoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "buikhanhtoan",
                columns: table => new
                {
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buikhanhtoan", x => x.FullName);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "buikhanhtoan");
        }
    }
}
