using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quizzler.Migrations
{
    /// <inheritdoc />
    public partial class QuestionTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BinaryQuestion_answer",
                table: "Questions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MultipleChoiceQuestion_answer",
                table: "Questions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "NumericQuestion_answer",
                table: "Questions",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionType",
                table: "Questions",
                type: "TEXT",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "answer",
                table: "Questions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "lowerBound",
                table: "Questions",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "options",
                table: "Questions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "upperbound",
                table: "Questions",
                type: "REAL",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BinaryQuestion_answer",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "MultipleChoiceQuestion_answer",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "NumericQuestion_answer",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "answer",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "lowerBound",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "options",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "upperbound",
                table: "Questions");
        }
    }
}
