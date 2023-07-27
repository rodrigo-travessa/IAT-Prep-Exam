using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IatPrepExam.Migrations
{
    /// <inheritdoc />
    public partial class manyToManyRelationShipAddedToQuizzAndQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_QuizzId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuizzId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuizzId",
                table: "Questions");

            migrationBuilder.AlterColumn<string>(
                name: "NameOfStudent",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "QuestionQuizz",
                columns: table => new
                {
                    QuestionsQuestionId = table.Column<int>(type: "int", nullable: false),
                    QuizzesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionQuizz", x => new { x.QuestionsQuestionId, x.QuizzesId });
                    table.ForeignKey(
                        name: "FK_QuestionQuizz_Questions_QuestionsQuestionId",
                        column: x => x.QuestionsQuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionQuizz_Quizzes_QuizzesId",
                        column: x => x.QuizzesId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionQuizz_QuizzesId",
                table: "QuestionQuizz",
                column: "QuizzesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionQuizz");

            migrationBuilder.AlterColumn<string>(
                name: "NameOfStudent",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuizzId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizzId",
                table: "Questions",
                column: "QuizzId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_QuizzId",
                table: "Questions",
                column: "QuizzId",
                principalTable: "Quizzes",
                principalColumn: "Id");
        }
    }
}
