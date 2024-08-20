using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dio_Veiculos.API.Migrations
{
    /// <inheritdoc />
    public partial class Veiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marca = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Ano = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    Placa = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Veiculos",
                columns: new[] { "Id", "Ano", "Marca", "Modelo", "Placa" },
                values: new object[] { 1, "2007", "GM", "Corsa Hatch Maxx", "HYT3151" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
