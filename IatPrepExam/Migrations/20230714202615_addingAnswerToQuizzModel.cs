using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IatPrepExam.Migrations
{
    /// <inheritdoc />
    public partial class addingAnswerToQuizzModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Answers",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Answers",
                newName: "id");
        }
    }
}
