using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace selecciontalento_api.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    EstCategory = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RolName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    RolDescription = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UsuName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    UsuLastName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    UsuTypeDni = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    UsuNumDni = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    UsuNumPhone = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    UsuEmail = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    UsuPassword = table.Column<string>(type: "longtext", nullable: false),
                    UsuAttempts = table.Column<int>(type: "int", nullable: false),
                    UsuProfilePicture = table.Column<string>(type: "longtext", nullable: true),
                    UsuAdicionalArchive = table.Column<string>(type: "longtext", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    EstId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Estados_EstId",
                        column: x => x.EstId,
                        principalTable: "Estados",
                        principalColumn: "EstId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EstId",
                table: "Usuarios",
                column: "EstId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
