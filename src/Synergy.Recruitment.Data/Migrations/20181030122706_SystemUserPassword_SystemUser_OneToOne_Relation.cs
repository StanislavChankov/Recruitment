using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Migrations
{
    public partial class SystemUserPassword_SystemUser_OneToOne_Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SystemUserPassword_SystemUserId",
                schema: "Identity",
                table: "SystemUserPassword");

            migrationBuilder.AddColumn<long>(
                name: "PasswordId",
                schema: "Identity",
                table: "SystemUser",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPassword_SystemUserId",
                schema: "Identity",
                table: "SystemUserPassword",
                column: "SystemUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SystemUserPassword_SystemUserId",
                schema: "Identity",
                table: "SystemUserPassword");

            migrationBuilder.DropColumn(
                name: "PasswordId",
                schema: "Identity",
                table: "SystemUser");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPassword_SystemUserId",
                schema: "Identity",
                table: "SystemUserPassword",
                column: "SystemUserId");
        }
    }
}
