using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClintName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitiationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duration = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects_Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_Id = table.Column<int>(type: "int", nullable: false),
                    Employee_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Employee_Employees_Employee_id",
                        column: x => x.Employee_id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Employee_Projects_project_Id",
                        column: x => x.project_Id,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "Position", "firstName", "lastName", "phoneNo" },
                values: new object[] { 4, "12-2-3", "PS", "Tauqeer", "Ahmad", "99268661" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ClintName", "InitiationDate", "ProjectName", "duration" },
                values: new object[,]
                {
                    { 1, "Test Clint", "01-01-2021", "My Assignment", " 01-01-2022" },
                    { 2, "Test Clint2", "02-01-2021", "My Assignment2", " 02-01-2022" },
                    { 3, "Test Clint3", "03-01-2021", "My Assignment3", " 03-01-2022" }
                });

            migrationBuilder.InsertData(
                table: "Projects_Employee",
                columns: new[] { "Id", "Employee_id", "project_Id" },
                values: new object[] { 1, 4, 2 });

            migrationBuilder.InsertData(
                table: "Projects_Employee",
                columns: new[] { "Id", "Employee_id", "project_Id" },
                values: new object[] { 2, 4, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Employee_Employee_id",
                table: "Projects_Employee",
                column: "Employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Employee_project_Id",
                table: "Projects_Employee",
                column: "project_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects_Employee");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
