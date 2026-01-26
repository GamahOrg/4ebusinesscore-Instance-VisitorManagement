using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class FK_IsNotRequried : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitorPermissionSteps_CancelRequests_CancelRequestId",
                table: "VisitorPermissionSteps");

            migrationBuilder.DropIndex(
                name: "IX_VisitorPermissionSteps_CancelRequestId",
                table: "VisitorPermissionSteps");

            migrationBuilder.AlterColumn<Guid>(
                name: "CancelRequestId",
                table: "VisitorPermissionSteps",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorPermissionSteps_CancelRequestId",
                table: "VisitorPermissionSteps",
                column: "CancelRequestId",
                unique: true,
                filter: "[CancelRequestId] IS NOT NULL");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "CancelRequestId",
                table: "VisitorPermissionSteps",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
