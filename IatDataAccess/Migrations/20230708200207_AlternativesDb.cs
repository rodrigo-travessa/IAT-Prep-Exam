using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IatPrepExam.Migrations
{
    /// <inheritdoc />
    public partial class AlternativesDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternative_Question_QuestionId",
                table: "Alternative");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alternative",
                table: "Alternative");

            migrationBuilder.RenameTable(
                name: "Alternative",
                newName: "Alternatives");

            migrationBuilder.RenameIndex(
                name: "IX_Alternative_QuestionId",
                table: "Alternatives",
                newName: "IX_Alternatives_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alternatives",
                table: "Alternatives",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alternatives_Question_QuestionId",
                table: "Alternatives",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternatives_Question_QuestionId",
                table: "Alternatives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alternatives",
                table: "Alternatives");

            migrationBuilder.RenameTable(
                name: "Alternatives",
                newName: "Alternative");

            migrationBuilder.RenameIndex(
                name: "IX_Alternatives_QuestionId",
                table: "Alternative",
                newName: "IX_Alternative_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alternative",
                table: "Alternative",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alternative_Question_QuestionId",
                table: "Alternative",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
