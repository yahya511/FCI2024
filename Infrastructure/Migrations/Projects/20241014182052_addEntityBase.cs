using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.Projects
{
    /// <inheritdoc />
    public partial class addEntityBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Projects",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Projects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "EmployeesProjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "EmployeesProjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EmployeesProjects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "EmployeesProjects",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "EmployeesProjects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "EmployeesProjects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Departments",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Departments",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeesProjects");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "EmployeesProjects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EmployeesProjects");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "EmployeesProjects");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "EmployeesProjects");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "EmployeesProjects");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Departments");
        }
    }
}
