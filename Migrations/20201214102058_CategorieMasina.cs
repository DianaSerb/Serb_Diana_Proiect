using Microsoft.EntityFrameworkCore.Migrations;

namespace Serb_Diana_Proiect.Migrations
{
    public partial class CategorieMasina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MotorID",
                table: "Car",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Motor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipMotor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieMasina",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarID = table.Column<int>(nullable: false),
                    CategorieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieMasina", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorieMasina_Car_CarID",
                        column: x => x.CarID,
                        principalTable: "Car",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieMasina_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_MotorID",
                table: "Car",
                column: "MotorID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieMasina_CarID",
                table: "CategorieMasina",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieMasina_CategorieID",
                table: "CategorieMasina",
                column: "CategorieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Motor_MotorID",
                table: "Car",
                column: "MotorID",
                principalTable: "Motor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Motor_MotorID",
                table: "Car");

            migrationBuilder.DropTable(
                name: "CategorieMasina");

            migrationBuilder.DropTable(
                name: "Motor");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Car_MotorID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "MotorID",
                table: "Car");
        }
    }
}
