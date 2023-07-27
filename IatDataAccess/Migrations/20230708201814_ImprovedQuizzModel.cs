using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IatPrepExam.Migrations
{
    /// <inheritdoc />
    public partial class ImprovedQuizzModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameOfStudent",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfQuestions",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rights",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ScoreRatio",
                table: "Quizzes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameOfStudent",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "NumberOfQuestions",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "Rights",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "ScoreRatio",
                table: "Quizzes");
        }
    }
}
