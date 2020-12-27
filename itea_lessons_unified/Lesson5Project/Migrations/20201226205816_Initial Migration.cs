using Microsoft.EntityFrameworkCore.Migrations;

namespace Lesson5Project.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Population = table.Column<int>(type: "int", nullable: false),
                    SickCount = table.Column<int>(type: "int", nullable: false),
                    DeadCount = table.Column<int>(type: "int", nullable: false),
                    RecoveredCount = table.Column<int>(type: "int", nullable: false),
                    Vaccine = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Humans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IsSick = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Humans_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "DeadCount", "Name", "Population", "RecoveredCount", "SickCount", "Vaccine" },
                values: new object[] { 1, 317729, "US", 328200000, 16800450, 17860634, false });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "DeadCount", "Name", "Population", "RecoveredCount", "SickCount", "Vaccine" },
                values: new object[] { 2, 145810, "India", 1353150536, 9606111, 10055560, false });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "DeadCount", "Name", "Population", "RecoveredCount", "SickCount", "Vaccine" },
                values: new object[] { 3, 186764, "Brazil", 209500000, 6409986, 7238600, false });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CountryId", "DistrictName" },
                values: new object[,]
                {
                    { 1, 1, "Arizona" },
                    { 2, 1, "New York" },
                    { 3, 2, "Goa" },
                    { 4, 2, "Bihar" },
                    { 5, 3, "Acre" },
                    { 6, 3, "Bahia" }
                });

            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "Id", "Age", "DistrictId", "FirstName", "Gender", "IsSick", "LastName" },
                values: new object[,]
                {
                    { 1, 38, 1, "Obi-wan", "Male", false, "Kenobi" },
                    { 2, 54, 2, "Sanwise", "Male", false, "Gamgee" },
                    { 3, 30, 3, "Hose", "Male", true, "Rodriges" },
                    { 4, 43, 4, "Consuela", "Female", false, "Tridana" },
                    { 5, 25, 5, "Ana", "Female", true, "Cormelia" },
                    { 6, 84, 6, "Thomas", "Male", true, "Edison" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CountryId",
                table: "Districts",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Humans_DistrictId",
                table: "Humans",
                column: "DistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Humans");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
