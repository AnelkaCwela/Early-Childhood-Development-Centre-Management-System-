using Microsoft.EntityFrameworkCore.Migrations;

namespace Algorithm_3rd_Year_Project.Migrations
{
    public partial class hugfl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "CentreManageTbl",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "CentreManageTbl");
        }
    }
}
