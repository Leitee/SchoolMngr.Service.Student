using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolMngr.Services.Academe.Infrastructure.Persistence.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DOMAIN");

            migrationBuilder.CreateTable(
                name: "Attendances",
                schema: "DOMAIN",
                columns: table => new
                {
                    AttendID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Attendance = table.Column<int>(type: "int", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.AttendID);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                schema: "DOMAIN",
                columns: table => new
                {
                    ExamID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamType = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "DOMAIN",
                columns: table => new
                {
                    StudentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IdentityUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                schema: "DOMAIN",
                columns: table => new
                {
                    SubjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "AcademicStatuses",
                schema: "DOMAIN",
                columns: table => new
                {
                    StatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademicStatus = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicStatuses", x => x.StatusID);
                    table.ForeignKey(
                        name: "FK_AcademicStatuses_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "DOMAIN",
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                schema: "DOMAIN",
                columns: table => new
                {
                    EnrollID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollID);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "DOMAIN",
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "DOMAIN",
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                schema: "DOMAIN",
                columns: table => new
                {
                    RecordID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AttandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AttendId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnrollmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordID);
                    table.ForeignKey(
                        name: "FK_Records_Attendances_AttendId",
                        column: x => x.AttendId,
                        principalSchema: "DOMAIN",
                        principalTable: "Attendances",
                        principalColumn: "AttendID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Records_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalSchema: "DOMAIN",
                        principalTable: "Enrollments",
                        principalColumn: "EnrollID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_Exams_ExamId",
                        column: x => x.ExamId,
                        principalSchema: "DOMAIN",
                        principalTable: "Exams",
                        principalColumn: "ExamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicStatuses_StudentId",
                schema: "DOMAIN",
                table: "AcademicStatuses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                schema: "DOMAIN",
                table: "Enrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_SubjectId",
                schema: "DOMAIN",
                table: "Enrollments",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_AttendId",
                schema: "DOMAIN",
                table: "Records",
                column: "AttendId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_EnrollmentId",
                schema: "DOMAIN",
                table: "Records",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_ExamId",
                schema: "DOMAIN",
                table: "Records",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProfileId",
                schema: "DOMAIN",
                table: "Students",
                column: "ProfileId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicStatuses",
                schema: "DOMAIN");

            migrationBuilder.DropTable(
                name: "Records",
                schema: "DOMAIN");

            migrationBuilder.DropTable(
                name: "Attendances",
                schema: "DOMAIN");

            migrationBuilder.DropTable(
                name: "Enrollments",
                schema: "DOMAIN");

            migrationBuilder.DropTable(
                name: "Exams",
                schema: "DOMAIN");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "DOMAIN");

            migrationBuilder.DropTable(
                name: "Subjects",
                schema: "DOMAIN");
        }
    }
}
