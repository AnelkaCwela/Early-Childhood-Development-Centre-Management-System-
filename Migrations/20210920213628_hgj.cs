using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Algorithm_3rd_Year_Project.Migrations
{
    public partial class hgj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CellNo",
                table: "teacherTbl");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "teacherTbl");

            migrationBuilder.DropColumn(
                name: "CellNo",
                table: "LiaisonTbl");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "LiaisonTbl");

            migrationBuilder.DropColumn(
                name: "CellNo",
                table: "CoodinatorTbl");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "CoodinatorTbl");

            migrationBuilder.DropColumn(
                name: "CellNo",
                table: "CentreManageTbl");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "CentreManageTbl");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "ParentTbl",
                newName: "IdNo");

            migrationBuilder.RenameColumn(
                name: "CellNo",
                table: "ParentTbl",
                newName: "City");

            migrationBuilder.AddColumn<byte[]>(
                name: "Profile",
                table: "teacherTbl",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "birthDocument",
                table: "PupilTbl",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApplicationDate",
                table: "PupilTbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CentreId",
                table: "PupilTbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GanderId",
                table: "PupilTbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "PupilTbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ParentTbl",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "relationShip",
                table: "ParentTbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Profile",
                table: "LiaisonTbl",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enrole",
                table: "EnroleTbl",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "Profile",
                table: "CoodinatorTbl",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Profile",
                table: "CentreManageTbl",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CellNo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "GanderModelTbl",
                columns: table => new
                {
                    GanderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gander = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GanderModelTbl", x => x.GanderId);
                });

            migrationBuilder.CreateTable(
                name: "StatusTbl",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Statuse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTbl", x => x.StatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PupilTbl_GanderId",
                table: "PupilTbl",
                column: "GanderId");

            migrationBuilder.CreateIndex(
                name: "IX_PupilTbl_StatusId",
                table: "PupilTbl",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_PupilTbl_GanderModelTbl_GanderId",
                table: "PupilTbl",
                column: "GanderId",
                principalTable: "GanderModelTbl",
                principalColumn: "GanderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PupilTbl_StatusTbl_StatusId",
                table: "PupilTbl",
                column: "StatusId",
                principalTable: "StatusTbl",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PupilTbl_GanderModelTbl_GanderId",
                table: "PupilTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_PupilTbl_StatusTbl_StatusId",
                table: "PupilTbl");

            migrationBuilder.DropTable(
                name: "GanderModelTbl");

            migrationBuilder.DropTable(
                name: "StatusTbl");

            migrationBuilder.DropIndex(
                name: "IX_PupilTbl_GanderId",
                table: "PupilTbl");

            migrationBuilder.DropIndex(
                name: "IX_PupilTbl_StatusId",
                table: "PupilTbl");

            migrationBuilder.DropColumn(
                name: "Profile",
                table: "teacherTbl");

            migrationBuilder.DropColumn(
                name: "ApplicationDate",
                table: "PupilTbl");

            migrationBuilder.DropColumn(
                name: "CentreId",
                table: "PupilTbl");

            migrationBuilder.DropColumn(
                name: "GanderId",
                table: "PupilTbl");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "PupilTbl");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ParentTbl");

            migrationBuilder.DropColumn(
                name: "relationShip",
                table: "ParentTbl");

            migrationBuilder.DropColumn(
                name: "Profile",
                table: "LiaisonTbl");

            migrationBuilder.DropColumn(
                name: "Enrole",
                table: "EnroleTbl");

            migrationBuilder.DropColumn(
                name: "Profile",
                table: "CoodinatorTbl");

            migrationBuilder.DropColumn(
                name: "Profile",
                table: "CentreManageTbl");

            migrationBuilder.DropColumn(
                name: "CellNo",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IdNo",
                table: "ParentTbl",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "ParentTbl",
                newName: "CellNo");

            migrationBuilder.AddColumn<string>(
                name: "CellNo",
                table: "teacherTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "teacherTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<byte[]>(
                name: "birthDocument",
                table: "PupilTbl",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CellNo",
                table: "LiaisonTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "LiaisonTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CellNo",
                table: "CoodinatorTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "CoodinatorTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CellNo",
                table: "CentreManageTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "CentreManageTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
