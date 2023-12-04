using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Algorithm_3rd_Year_Project.Migrations
{
    public partial class hg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CentreSerViceTypeTbl",
                columns: table => new
                {
                    CentreServiceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentreSerViceTypeTbl", x => x.CentreServiceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ParentTbl",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CellNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentTbl", x => x.ParentId);
                });

            migrationBuilder.CreateTable(
                name: "ProvinceTbl",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvinceTbl", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "QualificationTbl",
                columns: table => new
                {
                    QualificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualificationName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationTbl", x => x.QualificationId);
                });

            migrationBuilder.CreateTable(
                name: "taskTbl",
                columns: table => new
                {
                    taskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    Percent_Contribution = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskTbl", x => x.taskId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PupilTbl",
                columns: table => new
                {
                    PupilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityNo = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    birthDocument = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PupilTbl", x => x.PupilId);
                    table.ForeignKey(
                        name: "FK_PupilTbl_ParentTbl_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ParentTbl",
                        principalColumn: "ParentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LiaisonTbl",
                columns: table => new
                {
                    LiaisonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CellNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    tittleModel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiaisonTbl", x => x.LiaisonId);
                    table.ForeignKey(
                        name: "FK_LiaisonTbl_ProvinceTbl_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "ProvinceTbl",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegionTbl",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionTbl", x => x.RegionId);
                    table.ForeignKey(
                        name: "FK_RegionTbl_ProvinceTbl_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "ProvinceTbl",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacherTbl",
                columns: table => new
                {
                    teacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CellNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QualificationId = table.Column<int>(type: "int", nullable: false),
                    tittleModel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacherTbl", x => x.teacherId);
                    table.ForeignKey(
                        name: "FK_teacherTbl_QualificationTbl_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "QualificationTbl",
                        principalColumn: "QualificationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoodinatorTbl",
                columns: table => new
                {
                    CoodinatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CellNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    tittleModel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoodinatorTbl", x => x.CoodinatorId);
                    table.ForeignKey(
                        name: "FK_CoodinatorTbl_RegionTbl_RegionId",
                        column: x => x.RegionId,
                        principalTable: "RegionTbl",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuburbTbl",
                columns: table => new
                {
                    SuburbId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuburbTbl", x => x.SuburbId);
                    table.ForeignKey(
                        name: "FK_SuburbTbl_RegionTbl_CityId",
                        column: x => x.CityId,
                        principalTable: "RegionTbl",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CentreTbl",
                columns: table => new
                {
                    CentreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CentreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CentreNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CentraEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CentreFaxNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuburbId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentreTbl", x => x.CentreId);
                    table.ForeignKey(
                        name: "FK_CentreTbl_SuburbTbl_SuburbId",
                        column: x => x.SuburbId,
                        principalTable: "SuburbTbl",
                        principalColumn: "SuburbId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CentreManageTbl",
                columns: table => new
                {
                    CentreManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CellNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CentreId = table.Column<int>(type: "int", nullable: false),
                    tittleModel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentreManageTbl", x => x.CentreManagerId);
                    table.ForeignKey(
                        name: "FK_CentreManageTbl_CentreTbl_CentreId",
                        column: x => x.CentreId,
                        principalTable: "CentreTbl",
                        principalColumn: "CentreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CentreProgramTbl",
                columns: table => new
                {
                    CentreProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramDescr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CentreId = table.Column<int>(type: "int", nullable: false),
                    YearOferd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentreProgramTbl", x => x.CentreProgramId);
                    table.ForeignKey(
                        name: "FK_CentreProgramTbl_CentreTbl_CentreId",
                        column: x => x.CentreId,
                        principalTable: "CentreTbl",
                        principalColumn: "CentreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CentreServiceTbl",
                columns: table => new
                {
                    CentreServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicePrice = table.Column<double>(type: "float", nullable: false),
                    serviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CentreServiceTypeId = table.Column<int>(type: "int", nullable: false),
                    CentreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentreServiceTbl", x => x.CentreServiceId);
                    table.ForeignKey(
                        name: "FK_CentreServiceTbl_CentreSerViceTypeTbl_CentreServiceTypeId",
                        column: x => x.CentreServiceTypeId,
                        principalTable: "CentreSerViceTypeTbl",
                        principalColumn: "CentreServiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CentreServiceTbl_CentreTbl_CentreId",
                        column: x => x.CentreId,
                        principalTable: "CentreTbl",
                        principalColumn: "CentreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgrameOfferdTbl",
                columns: table => new
                {
                    ProgrameOfferdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CentreProgramId = table.Column<int>(type: "int", nullable: false),
                    teacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrameOfferdTbl", x => x.ProgrameOfferdId);
                    table.ForeignKey(
                        name: "FK_ProgrameOfferdTbl_CentreProgramTbl_CentreProgramId",
                        column: x => x.CentreProgramId,
                        principalTable: "CentreProgramTbl",
                        principalColumn: "CentreProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgrameOfferdTbl_teacherTbl_teacherId",
                        column: x => x.teacherId,
                        principalTable: "teacherTbl",
                        principalColumn: "teacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnroleTbl",
                columns: table => new
                {
                    EnroleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnroleYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PupilId = table.Column<int>(type: "int", nullable: false),
                    ProgrameOfferdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnroleTbl", x => x.EnroleId);
                    table.ForeignKey(
                        name: "FK_EnroleTbl_ProgrameOfferdTbl_ProgrameOfferdId",
                        column: x => x.ProgrameOfferdId,
                        principalTable: "ProgrameOfferdTbl",
                        principalColumn: "ProgrameOfferdId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnroleTbl_PupilTbl_PupilId",
                        column: x => x.PupilId,
                        principalTable: "PupilTbl",
                        principalColumn: "PupilId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceTbl",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attend = table.Column<bool>(type: "bit", nullable: false),
                    AttanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnroleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceTbl", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_AttendanceTbl_EnroleTbl_EnroleId",
                        column: x => x.EnroleId,
                        principalTable: "EnroleTbl",
                        principalColumn: "EnroleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarksTbl",
                columns: table => new
                {
                    MarksId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EnroleId = table.Column<int>(type: "int", nullable: false),
                    taskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarksTbl", x => x.MarksId);
                    table.ForeignKey(
                        name: "FK_MarksTbl_EnroleTbl_EnroleId",
                        column: x => x.EnroleId,
                        principalTable: "EnroleTbl",
                        principalColumn: "EnroleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarksTbl_taskTbl_taskId",
                        column: x => x.taskId,
                        principalTable: "taskTbl",
                        principalColumn: "taskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceTbl_EnroleId",
                table: "AttendanceTbl",
                column: "EnroleId");

            migrationBuilder.CreateIndex(
                name: "IX_CentreManageTbl_CentreId",
                table: "CentreManageTbl",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_CentreProgramTbl_CentreId",
                table: "CentreProgramTbl",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_CentreServiceTbl_CentreId",
                table: "CentreServiceTbl",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_CentreServiceTbl_CentreServiceTypeId",
                table: "CentreServiceTbl",
                column: "CentreServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CentreTbl_SuburbId",
                table: "CentreTbl",
                column: "SuburbId");

            migrationBuilder.CreateIndex(
                name: "IX_CoodinatorTbl_RegionId",
                table: "CoodinatorTbl",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_EnroleTbl_ProgrameOfferdId",
                table: "EnroleTbl",
                column: "ProgrameOfferdId");

            migrationBuilder.CreateIndex(
                name: "IX_EnroleTbl_PupilId",
                table: "EnroleTbl",
                column: "PupilId");

            migrationBuilder.CreateIndex(
                name: "IX_LiaisonTbl_ProvinceId",
                table: "LiaisonTbl",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_MarksTbl_EnroleId",
                table: "MarksTbl",
                column: "EnroleId");

            migrationBuilder.CreateIndex(
                name: "IX_MarksTbl_taskId",
                table: "MarksTbl",
                column: "taskId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrameOfferdTbl_CentreProgramId",
                table: "ProgrameOfferdTbl",
                column: "CentreProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrameOfferdTbl_teacherId",
                table: "ProgrameOfferdTbl",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX_PupilTbl_ParentId",
                table: "PupilTbl",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionTbl_ProvinceId",
                table: "RegionTbl",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_SuburbTbl_CityId",
                table: "SuburbTbl",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_teacherTbl_QualificationId",
                table: "teacherTbl",
                column: "QualificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AttendanceTbl");

            migrationBuilder.DropTable(
                name: "CentreManageTbl");

            migrationBuilder.DropTable(
                name: "CentreServiceTbl");

            migrationBuilder.DropTable(
                name: "CoodinatorTbl");

            migrationBuilder.DropTable(
                name: "LiaisonTbl");

            migrationBuilder.DropTable(
                name: "MarksTbl");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CentreSerViceTypeTbl");

            migrationBuilder.DropTable(
                name: "EnroleTbl");

            migrationBuilder.DropTable(
                name: "taskTbl");

            migrationBuilder.DropTable(
                name: "ProgrameOfferdTbl");

            migrationBuilder.DropTable(
                name: "PupilTbl");

            migrationBuilder.DropTable(
                name: "CentreProgramTbl");

            migrationBuilder.DropTable(
                name: "teacherTbl");

            migrationBuilder.DropTable(
                name: "ParentTbl");

            migrationBuilder.DropTable(
                name: "CentreTbl");

            migrationBuilder.DropTable(
                name: "QualificationTbl");

            migrationBuilder.DropTable(
                name: "SuburbTbl");

            migrationBuilder.DropTable(
                name: "RegionTbl");

            migrationBuilder.DropTable(
                name: "ProvinceTbl");
        }
    }
}
