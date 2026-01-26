using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeInVisitor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NewEndDate",
                table: "Visitors",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "NewEndTime",
                table: "Visitors",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NewStartDate",
                table: "Visitors",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "NewStartTime",
                table: "Visitors",
                type: "time",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewEndDate",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "NewEndTime",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "NewStartDate",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "NewStartTime",
                table: "Visitors");
        }
    }
}
