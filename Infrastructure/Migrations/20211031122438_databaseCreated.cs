using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class databaseCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Examinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Process = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bill = table.Column<int>(type: "int", nullable: false),
                    HaveInsurance = table.Column<bool>(type: "bit", nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isJudical = table.Column<bool>(type: "bit", nullable: false),
                    OfficeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fix = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insurance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Fix = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegInsurance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bill = table.Column<int>(type: "int", nullable: false),
                    Fix = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegInsurance", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examinations");

            migrationBuilder.DropTable(
                name: "Insurance");

            migrationBuilder.DropTable(
                name: "RegInsurance");
        }
    }
}
