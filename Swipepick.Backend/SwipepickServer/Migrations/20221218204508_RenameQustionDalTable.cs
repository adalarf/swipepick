using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwipepickServer.Migrations
{
    /// <inheritdoc />
    public partial class RenameQustionDalTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_QuestionDal_QuestionId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionDal_Test_TestId",
                table: "QuestionDal");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Test_TestId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionDal",
                table: "QuestionDal");

            migrationBuilder.RenameTable(
                name: "QuestionDal",
                newName: "test_question");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "Student",
                newName: "test_id");

            migrationBuilder.RenameIndex(
                name: "IX_Student_TestId",
                table: "Student",
                newName: "IX_Student_test_id");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionDal_TestId",
                table: "test_question",
                newName: "IX_test_question_TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_test_question",
                table: "test_question",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_test_question_QuestionId",
                table: "Answer",
                column: "QuestionId",
                principalTable: "test_question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Test_test_id",
                table: "Student",
                column: "test_id",
                principalTable: "Test",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_test_question_Test_TestId",
                table: "test_question",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_test_question_QuestionId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Test_test_id",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_test_question_Test_TestId",
                table: "test_question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_test_question",
                table: "test_question");

            migrationBuilder.RenameTable(
                name: "test_question",
                newName: "QuestionDal");

            migrationBuilder.RenameColumn(
                name: "test_id",
                table: "Student",
                newName: "TestId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_test_id",
                table: "Student",
                newName: "IX_Student_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_test_question_TestId",
                table: "QuestionDal",
                newName: "IX_QuestionDal_TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionDal",
                table: "QuestionDal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_QuestionDal_QuestionId",
                table: "Answer",
                column: "QuestionId",
                principalTable: "QuestionDal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionDal_Test_TestId",
                table: "QuestionDal",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Test_TestId",
                table: "Student",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
