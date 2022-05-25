using Microsoft.EntityFrameworkCore.Migrations;

namespace labb2Linq.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Grades_GradeName",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GradeName",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "GradeName",
                table: "Students",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "GradeName1",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_GradeName1",
                table: "Students",
                column: "GradeName1");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Grades_GradeName1",
                table: "Students",
                column: "GradeName1",
                principalTable: "Grades",
                principalColumn: "GradeName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Grades_GradeName1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GradeName1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GradeName1",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "GradeName",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Students_GradeName",
                table: "Students",
                column: "GradeName");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Grades_GradeName",
                table: "Students",
                column: "GradeName",
                principalTable: "Grades",
                principalColumn: "GradeName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
