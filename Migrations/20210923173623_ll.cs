using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Algorithm_3rd_Year_Project.Migrations
{
    public partial class ll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuburbTbl_RegionTbl_CityId",
                table: "SuburbTbl");

            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "MarksTbl");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "SuburbTbl",
                newName: "RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_SuburbTbl_CityId",
                table: "SuburbTbl",
                newName: "IX_SuburbTbl_RegionId");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Profile",
                table: "teacherTbl",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CentreId",
                table: "teacherTbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "teacherTbl",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "SuburbTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PupilId",
                table: "MarksTbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "CoodinatorTbl",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "CentreManageTbl",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PupilId",
                table: "AttendanceTbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_SuburbTbl_RegionTbl_RegionId",
                table: "SuburbTbl",
                column: "RegionId",
                principalTable: "RegionTbl",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuburbTbl_RegionTbl_RegionId",
                table: "SuburbTbl");

            migrationBuilder.DropColumn(
                name: "CentreId",
                table: "teacherTbl");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "teacherTbl");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "SuburbTbl");

            migrationBuilder.DropColumn(
                name: "PupilId",
                table: "MarksTbl");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "CoodinatorTbl");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "CentreManageTbl");

            migrationBuilder.DropColumn(
                name: "PupilId",
                table: "AttendanceTbl");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "SuburbTbl",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_SuburbTbl_RegionId",
                table: "SuburbTbl",
                newName: "IX_SuburbTbl_CityId");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Profile",
                table: "teacherTbl",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "Percentage",
                table: "MarksTbl",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_SuburbTbl_RegionTbl_CityId",
                table: "SuburbTbl",
                column: "CityId",
                principalTable: "RegionTbl",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
