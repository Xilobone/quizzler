using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quizzler.Migrations
{
    /// <inheritdoc />
    public partial class OwnerOfQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ownerId",
                table: "Questions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ownerId",
                table: "Questions",
                column: "ownerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_ownerId",
                table: "Questions",
                column: "ownerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_ownerId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_ownerId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ownerId",
                table: "Questions");
        }
    }
}
