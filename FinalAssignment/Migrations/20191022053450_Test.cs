using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalAssignment.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "remark",
                table: "Appraisals",
                newName: "Remark");

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "Appraisals",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Test1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Test2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TestId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Test2_Test1_TestId",
                        column: x => x.TestId,
                        principalTable: "Test1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Test2_TestId",
                table: "Test2",
                column: "TestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test2");

            migrationBuilder.DropTable(
                name: "Test1");

            migrationBuilder.RenameColumn(
                name: "Remark",
                table: "Appraisals",
                newName: "remark");

            migrationBuilder.AlterColumn<string>(
                name: "remark",
                table: "Appraisals",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);
        }
    }
}
