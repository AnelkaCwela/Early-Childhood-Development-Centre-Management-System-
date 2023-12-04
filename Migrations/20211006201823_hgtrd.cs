using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Algorithm_3rd_Year_Project.Migrations
{
    public partial class hgtrd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percent_Contribution",
                table: "taskTbl");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Profile",
                table: "teacherTbl",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Profile",
                table: "teacherTbl",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Percent_Contribution",
                table: "taskTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
