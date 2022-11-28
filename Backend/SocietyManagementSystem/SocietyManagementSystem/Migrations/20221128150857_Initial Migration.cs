using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocietyManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinanceDepartments",
                columns: table => new
                {
                    BudgetApproverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceDepartments", x => x.BudgetApproverId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployementType = table.Column<string>(name: "Employement_Type", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "Societies",
                columns: table => new
                {
                    SocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Announcement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<int>(type: "int", nullable: false),
                    Presidentid = table.Column<string>(name: "President_id", type: "nvarchar(450)", nullable: true),
                    Vicepresidentid = table.Column<string>(name: "Vice_president_id", type: "nvarchar(max)", nullable: true),
                    Treasurerid = table.Column<string>(name: "Treasurer_id", type: "nvarchar(max)", nullable: true),
                    Gsid = table.Column<string>(name: "Gs_id", type: "nvarchar(max)", nullable: true),
                    Facultyheadid = table.Column<string>(name: "Faculty_head_id", type: "nvarchar(450)", nullable: false),
                    Facultycoheadid = table.Column<string>(name: "Faculty_cohead_id", type: "nvarchar(max)", nullable: false),
                    BudgetApproverId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societies", x => x.SocietyId);
                    table.ForeignKey(
                        name: "FK_Societies_FinanceDepartments_BudgetApproverId",
                        column: x => x.BudgetApproverId,
                        principalTable: "FinanceDepartments",
                        principalColumn: "BudgetApproverId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Societies_Students_President_id",
                        column: x => x.Presidentid,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                    table.ForeignKey(
                        name: "FK_Societies_Teachers_Faculty_head_id",
                        column: x => x.Facultyheadid,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventType = table.Column<string>(name: "Event_Type", type: "nvarchar(max)", nullable: false),
                    Guestname = table.Column<string>(name: "Guest_name", type: "nvarchar(max)", nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(name: "Date_Time", type: "datetime2", nullable: false),
                    SocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Societies_SocietyId",
                        column: x => x.SocietyId,
                        principalTable: "Societies",
                        principalColumn: "SocietyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    RegistrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registrations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_SocietyId",
                table: "Events",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_EventId",
                table: "Registrations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_StudentId",
                table: "Registrations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Societies_BudgetApproverId",
                table: "Societies",
                column: "BudgetApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_Societies_Faculty_head_id",
                table: "Societies",
                column: "Faculty_head_id");

            migrationBuilder.CreateIndex(
                name: "IX_Societies_President_id",
                table: "Societies",
                column: "President_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Societies");

            migrationBuilder.DropTable(
                name: "FinanceDepartments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
