using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bacteriums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bacteriums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cholecystits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Degree = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Symptoms = table.Column<string>(type: "text", nullable: true),
                    Pathophysiology = table.Column<string>(type: "text", nullable: true),
                    Histology = table.Column<string>(type: "text", nullable: true),
                    CausedComplications = table.Column<string>(type: "text", nullable: true),
                    Treatment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cholecystits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: true),
                    Сomposition = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BacteriumCholecystit",
                columns: table => new
                {
                    BacteriasId = table.Column<int>(type: "integer", nullable: false),
                    CholecystitsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BacteriumCholecystit", x => new { x.BacteriasId, x.CholecystitsId });
                    table.ForeignKey(
                        name: "FK_BacteriumCholecystit_Bacteriums_BacteriasId",
                        column: x => x.BacteriasId,
                        principalTable: "Bacteriums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BacteriumCholecystit_Cholecystits_CholecystitsId",
                        column: x => x.CholecystitsId,
                        principalTable: "Cholecystits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    RiskFactors = table.Column<string>(type: "text", nullable: true),
                    CholecystitId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Cholecystits_CholecystitId",
                        column: x => x.CholecystitId,
                        principalTable: "Cholecystits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CholecystitStone",
                columns: table => new
                {
                    CholecystitsId = table.Column<int>(type: "integer", nullable: false),
                    StonesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CholecystitStone", x => new { x.CholecystitsId, x.StonesId });
                    table.ForeignKey(
                        name: "FK_CholecystitStone_Cholecystits_CholecystitsId",
                        column: x => x.CholecystitsId,
                        principalTable: "Cholecystits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CholecystitStone_Stones_StonesId",
                        column: x => x.StonesId,
                        principalTable: "Stones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bacteriums",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Test" });

            migrationBuilder.CreateIndex(
                name: "IX_BacteriumCholecystit_CholecystitsId",
                table: "BacteriumCholecystit",
                column: "CholecystitsId");

            migrationBuilder.CreateIndex(
                name: "IX_CholecystitStone_StonesId",
                table: "CholecystitStone",
                column: "StonesId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_CholecystitId",
                table: "Patients",
                column: "CholecystitId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BacteriumCholecystit");

            migrationBuilder.DropTable(
                name: "CholecystitStone");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Bacteriums");

            migrationBuilder.DropTable(
                name: "Stones");

            migrationBuilder.DropTable(
                name: "Cholecystits");
        }
    }
}
