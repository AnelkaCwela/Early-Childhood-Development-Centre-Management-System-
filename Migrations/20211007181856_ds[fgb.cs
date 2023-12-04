using Microsoft.EntityFrameworkCore.Migrations;

namespace Algorithm_3rd_Year_Project.Migrations
{
    public partial class dsfgb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CentreId",
                table: "taskTbl",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CentreId",
                table: "taskTbl");
        }
    }
}
