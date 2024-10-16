using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.Employees
{
    /// <inheritdoc />
    public partial class addEntityBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Towns",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Towns",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Towns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Towns",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Towns",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Towns",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Employees",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Addresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Addresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Addresses",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Addresses",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Towns");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Towns");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Towns");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Towns");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Towns");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Towns");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
