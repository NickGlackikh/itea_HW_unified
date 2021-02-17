using Microsoft.EntityFrameworkCore.Migrations;

namespace ITEAProject.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Address", "Phone" },
                values: new object[,]
                {
                    { 1, "1 Sobornyj ave. Zaporizhzhya", null },
                    { 2, "2 Yavornytskogo ave. Dnipro", null },
                    { 3, "3 Khreschshatyk str. Kyiv", null }
                });

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "Id", "BreedDescription", "BreedName" },
                values: new object[,]
                {
                    { 1, "Description1", "German Shepherd" },
                    { 2, "Description2", "Bigl" },
                    { 3, "Description3", "French Bulldog" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "OwnerName", "Phone" },
                values: new object[,]
                {
                    { 1, "23, Yablochnaya Street, Zaporizhzhya", "Ivanov I.I.", "+380661234567" },
                    { 2, "35, Myra Street, Vinnitsya", "Petrov A.I.", "+380950001144" },
                    { 3, "90, Shevchenko Street, Kharkiv", "Golovanova I.O.", "+380939339393" }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Age", "BranchId", "BreedId", "Gender", "OwnerId", "PetName" },
                values: new object[,]
                {
                    { 2, 1, 1, 1, 1, null, "Joe" },
                    { 4, 3, 2, 1, 1, null, "Rex" },
                    { 1, 3, 1, 2, 2, null, "Berta" },
                    { 5, 3, 3, 2, 2, null, "Knopa" },
                    { 6, 3, 3, 2, 1, null, "Toby" },
                    { 3, 2, 2, 3, 1, null, "Nick" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_BranchId",
                table: "Pets",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_BreedId",
                table: "Pets",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_OwnerId",
                table: "Pets",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
