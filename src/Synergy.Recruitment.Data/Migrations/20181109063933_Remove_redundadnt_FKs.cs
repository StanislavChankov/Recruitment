using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Migrations
{
    public partial class Remove_redundadnt_FKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SystemUserPasswordId",
                schema: "Identity",
                table: "SystemUser");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                schema: "Identity",
                table: "Person");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                schema: "Identity",
                table: "SystemUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                schema: "Identity",
                table: "SystemUser",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Identity",
                table: "Role",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "Identity",
                table: "Role",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                schema: "Identity",
                table: "SystemUser");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                schema: "Identity",
                table: "SystemUser");

            migrationBuilder.AddColumn<long>(
                name: "SystemUserPasswordId",
                schema: "Identity",
                table: "SystemUser",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Identity",
                table: "Role",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "Identity",
                table: "Role",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SystemUserId",
                schema: "Identity",
                table: "Person",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
