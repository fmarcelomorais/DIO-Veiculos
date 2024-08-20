using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dio_Veiculos.API.Migrations
{
    /// <inheritdoc />
    public partial class Administrator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Passworld = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Perfil = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "Email", "Name", "Passworld", "Perfil" },
                values: new object[] { 1, "admin@admin.com", "Administrator", "123456", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");
        }
    }
}
