using Microsoft.EntityFrameworkCore.Migrations;

namespace sdgreacttemplate.Migrations
{
    public partial class AddedColumnAndEndPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfViews",
                table: "QuestionPosts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfViews",
                table: "QuestionPosts");
        }
    }
}
