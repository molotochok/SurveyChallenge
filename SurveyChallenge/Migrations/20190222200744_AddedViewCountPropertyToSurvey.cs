using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyChallenge.Migrations
{
    public partial class AddedViewCountPropertyToSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Surveys",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Surveys");
        }
    }
}
