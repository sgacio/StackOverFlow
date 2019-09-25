using Microsoft.EntityFrameworkCore.Migrations;

namespace sdgreacttemplate.Migrations
{
    public partial class ConnectedTablesInOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswersPostId",
                table: "QuestionPosts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionPosts_AnswersPostId",
                table: "QuestionPosts",
                column: "AnswersPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionPosts_AnswerPosts_AnswersPostId",
                table: "QuestionPosts",
                column: "AnswersPostId",
                principalTable: "AnswerPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionPosts_AnswerPosts_AnswersPostId",
                table: "QuestionPosts");

            migrationBuilder.DropIndex(
                name: "IX_QuestionPosts_AnswersPostId",
                table: "QuestionPosts");

            migrationBuilder.DropColumn(
                name: "AnswersPostId",
                table: "QuestionPosts");
        }
    }
}
