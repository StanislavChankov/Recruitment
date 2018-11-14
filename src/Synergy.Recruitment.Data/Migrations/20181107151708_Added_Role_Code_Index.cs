using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Migrations
{
    public partial class Added_Role_Code_Index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleActionUser");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Identity",
                table: "Role",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "Identity",
                table: "Role",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "Identity",
                table: "Person",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "Identity",
                table: "Person",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                schema: "Identity",
                table: "Person",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Identity",
                table: "Organization",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Identity",
                table: "Action",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_Code",
                schema: "Identity",
                table: "Role",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Person_EmailAddress",
                schema: "Identity",
                table: "Person",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organization_Name",
                schema: "Identity",
                table: "Organization",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Role_Code",
                schema: "Identity",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Person_EmailAddress",
                schema: "Identity",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Organization_Name",
                schema: "Identity",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "Identity",
                table: "Role");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Identity",
                table: "Role",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "Identity",
                table: "Person",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "Identity",
                table: "Person",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                schema: "Identity",
                table: "Person",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Identity",
                table: "Organization",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Identity",
                table: "Action",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RoleActionUser",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleActionOrganizationId = table.Column<long>(nullable: false),
                    SystemUserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleActionUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleActionUser_RoleActionOrganization_RoleActionOrganizationId",
                        column: x => x.RoleActionOrganizationId,
                        principalSchema: "Identity",
                        principalTable: "RoleActionOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleActionUser_SystemUser_SystemUserId",
                        column: x => x.SystemUserId,
                        principalSchema: "Identity",
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleActionUser_RoleActionOrganizationId",
                table: "RoleActionUser",
                column: "RoleActionOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActionUser_SystemUserId",
                table: "RoleActionUser",
                column: "SystemUserId");
        }
    }
}
