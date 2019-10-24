using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalAssignment.Migrations
{
    public partial class Appraisals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LeavingDate",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "Appraisals",
                columns: table => new
                {
                    AppraisalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: false),
                    CurrentAppraisal = table.Column<DateTime>(nullable: false),
                    NextAppraisal = table.Column<DateTime>(nullable: false),
                    FilesName = table.Column<string>(nullable: true),
                    remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appraisals", x => x.AppraisalId);
                    table.ForeignKey(
                        name: "FK_Appraisals_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appraisals_EmployeeId",
                table: "Appraisals",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appraisals");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LeavingDate",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
