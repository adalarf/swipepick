using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwipepickServer.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnToAnswerDal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Answer",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Answer");
        }
    }
}
