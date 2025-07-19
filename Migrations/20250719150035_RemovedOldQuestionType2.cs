using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quizzler.Migrations
{
    /// <inheritdoc />
    public partial class RemovedOldQuestionType2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "Questions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionType",
                table: "Questions",
                type: "TEXT",
                maxLength: 21,
                nullable: false,
                defaultValue: "");
        }
    }
}
