using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class EditInTableCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateIn",
                table: "CheckIn_OutVisitor");

            migrationBuilder.RenameColumn(
                name: "DateOut",
                table: "CheckIn_OutVisitor",
                newName: "Date");

            migrationBuilder.AddColumn<bool>(
                name: "ISTransit",
                table: "CheckIn_OutVisitor",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TransitComment",
                table: "CheckIn_OutVisitor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransitStatus",
                table: "CheckIn_OutVisitor",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISTransit",
                table: "CheckIn_OutVisitor");

            migrationBuilder.DropColumn(
                name: "TransitComment",
                table: "CheckIn_OutVisitor");

            migrationBuilder.DropColumn(
                name: "TransitStatus",
                table: "CheckIn_OutVisitor");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "CheckIn_OutVisitor",
                newName: "DateOut");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateIn",
                table: "CheckIn_OutVisitor",
                type: "datetime2",
                nullable: true);
        }
    }
}
