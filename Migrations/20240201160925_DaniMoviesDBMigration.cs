using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blockbuster.Migrations
{
    /// <inheritdoc />
    public partial class DaniMoviesDBMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);


                });

             migrationBuilder.InsertData(
                 table: "Movies",
                 columns: new[] { "Id", "Title", "Genre", "Duration" },
                 values: new object[] { 1, "Oblivion", "Science fiction", "2h 4m" });

            migrationBuilder.InsertData(
                 table: "Movies",
                 columns: new[] { "Id", "Title", "Genre", "Duration" },
                 values: new object[] { 2, "BladeRunner2049", "Science fiction", "2h 43m" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Title", "Genre", "Duration" },
                values: new object[] { 3, "BladeRunner2049", "Science fiction", "2h 43m" });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

        }
    }
}
