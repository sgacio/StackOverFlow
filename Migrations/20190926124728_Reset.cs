using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace sdgreacttemplate.Migrations
{
    public partial class Reset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionPosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ShortDescription = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    PraisesForMyQuestionRelevance = table.Column<int>(nullable: false),
                    DateOfPost = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnswerPosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AnswerContent = table.Column<string>(nullable: true),
                    PraisesForMyAnswer = table.Column<int>(nullable: false),
                    DateOfPost = table.Column<DateTime>(nullable: false),
                    QuestionPostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerPosts_QuestionPosts_QuestionPostId",
                        column: x => x.QuestionPostId,
                        principalTable: "QuestionPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerPosts_QuestionPostId",
                table: "AnswerPosts",
                column: "QuestionPostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerPosts");

            migrationBuilder.DropTable(
                name: "QuestionPosts");
        }
    }
}
