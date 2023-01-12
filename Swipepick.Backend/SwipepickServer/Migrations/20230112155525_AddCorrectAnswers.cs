using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwipepickServer.Migrations
{
    /// <inheritdoc />
    public partial class AddCorrectAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorrectAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    TestId = table.Column<int>(type: "integer", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorrectAnswers_Test_Id",
                        column: x => x.Id,
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorrectAnswers");
        }
    }
}
