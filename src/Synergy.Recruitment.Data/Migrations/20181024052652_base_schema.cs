using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Migrations
{
    public partial class base_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies");

            migrationBuilder.RenameTable(
                name: "Technologies",
                newName: "Technology");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technology",
                table: "Technology",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterviewType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Process",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Position_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationProcess",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    ProcessId = table.Column<long>(type: "bigint", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationProcess_Process_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Process",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateInfo_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobAdvertisement",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PositionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAdvertisement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobAdvertisement_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidateInfoId = table.Column<long>(type: "bigint", nullable: false),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidate_CandidateInfo_CandidateInfoId",
                        column: x => x.CandidateInfoId,
                        principalTable: "CandidateInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateCompany",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidateId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateCompany_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateCompany_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateJobAdvertisment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidateId = table.Column<long>(type: "bigint", nullable: false),
                    JobAdvertismentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateJobAdvertisment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateJobAdvertisment_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateJobAdvertisment_JobAdvertisement_JobAdvertismentId",
                        column: x => x.JobAdvertismentId,
                        principalTable: "JobAdvertisement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interview",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidateId = table.Column<long>(type: "bigint", nullable: false),
                    InterviewTypeId = table.Column<long>(type: "bigint", nullable: false),
                    StartUtcDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interview_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interview_InterviewType_InterviewTypeId",
                        column: x => x.InterviewTypeId,
                        principalTable: "InterviewType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_CandidateInfoId",
                table: "Candidate",
                column: "CandidateInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCompany_CandidateId",
                table: "CandidateCompany",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCompany_CompanyId",
                table: "CandidateCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateInfo_CityId",
                table: "CandidateInfo",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateJobAdvertisment_CandidateId",
                table: "CandidateJobAdvertisment",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateJobAdvertisment_JobAdvertismentId",
                table: "CandidateJobAdvertisment",
                column: "JobAdvertismentId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_CandidateId",
                table: "Interview",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_InterviewTypeId",
                table: "Interview",
                column: "InterviewTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAdvertisement_PositionId",
                table: "JobAdvertisement",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationProcess_ProcessId",
                table: "OrganizationProcess",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_DepartmentId",
                table: "Position",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateCompany");

            migrationBuilder.DropTable(
                name: "CandidateJobAdvertisment");

            migrationBuilder.DropTable(
                name: "Interview");

            migrationBuilder.DropTable(
                name: "OrganizationProcess");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "JobAdvertisement");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "InterviewType");

            migrationBuilder.DropTable(
                name: "Process");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "CandidateInfo");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Technology",
                table: "Technology");

            migrationBuilder.RenameTable(
                name: "Technology",
                newName: "Technologies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies",
                column: "Id");
        }
    }
}
