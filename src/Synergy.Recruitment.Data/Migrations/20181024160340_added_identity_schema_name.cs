using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Migrations
{
    public partial class added_identity_schema_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.RenameTable(
                name: "SystemUserPassword",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "SystemUser",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "RoleActionUser",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "RoleActionOrganization",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Role",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Person",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Organization",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Action",
                newSchema: "Identity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "SystemUserPassword",
                schema: "Identity");

            migrationBuilder.RenameTable(
                name: "SystemUser",
                schema: "Identity");

            migrationBuilder.RenameTable(
                name: "RoleActionUser",
                schema: "Identity");

            migrationBuilder.RenameTable(
                name: "RoleActionOrganization",
                schema: "Identity");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "Identity");

            migrationBuilder.RenameTable(
                name: "Person",
                schema: "Identity");

            migrationBuilder.RenameTable(
                name: "Organization",
                schema: "Identity");

            migrationBuilder.RenameTable(
                name: "Action",
                schema: "Identity");
        }
    }
}
