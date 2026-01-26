using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class cancel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CancelRequestId",
                table: "VisitorPermissionSteps",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_VisitorPermissionSteps_CancelRequestId",
                table: "VisitorPermissionSteps",
                column: "CancelRequestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitorPermissionSteps_CancelRequests_CancelRequestId",
                table: "VisitorPermissionSteps",
                column: "CancelRequestId",
                principalTable: "CancelRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitorPermissionSteps_CancelRequests_CancelRequestId",
                table: "VisitorPermissionSteps");

            migrationBuilder.DropIndex(
                name: "IX_VisitorPermissionSteps_CancelRequestId",
                table: "VisitorPermissionSteps");

            migrationBuilder.DropColumn(
                name: "CancelRequestId",
                table: "VisitorPermissionSteps");
        }
    }
}
