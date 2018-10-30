using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Migrations
{
    public partial class SystemUser_Organization_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OrganizationId",
                schema: "Identity",
                table: "SystemUser",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                schema: "Identity",
                table: "Person",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateIndex(
                name: "IX_SystemUser_OrganizationId",
                schema: "Identity",
                table: "SystemUser",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemUser_Organization_OrganizationId",
                schema: "Identity",
                table: "SystemUser",
                column: "OrganizationId",
                principalSchema: "Identity",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemUser_Organization_OrganizationId",
                schema: "Identity",
                table: "SystemUser");

            migrationBuilder.DropIndex(
                name: "IX_SystemUser_OrganizationId",
                schema: "Identity",
                table: "SystemUser");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                schema: "Identity",
                table: "SystemUser");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                schema: "Identity",
                table: "Person",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
