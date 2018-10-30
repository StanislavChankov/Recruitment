using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Migrations
{
    public partial class Added_OneToOne_Person_SystemUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SystemUser_PersonId",
                schema: "Identity",
                table: "SystemUser");

            migrationBuilder.DropColumn(
                name: "PasswordId",
                schema: "Identity",
                table: "SystemUser");

            migrationBuilder.AddColumn<long>(
                name: "SystemUserPasswordId",
                schema: "Identity",
                table: "SystemUser",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SystemUserId",
                schema: "Identity",
                table: "Person",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_SystemUser_PersonId",
                schema: "Identity",
                table: "SystemUser",
                column: "PersonId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SystemUser_PersonId",
                schema: "Identity",
                table: "SystemUser");

            migrationBuilder.DropColumn(
                name: "SystemUserPasswordId",
                schema: "Identity",
                table: "SystemUser");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                schema: "Identity",
                table: "Person");

            migrationBuilder.AddColumn<long>(
                name: "PasswordId",
                schema: "Identity",
                table: "SystemUser",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_SystemUser_PersonId",
                schema: "Identity",
                table: "SystemUser",
                column: "PersonId");
        }
    }
}
