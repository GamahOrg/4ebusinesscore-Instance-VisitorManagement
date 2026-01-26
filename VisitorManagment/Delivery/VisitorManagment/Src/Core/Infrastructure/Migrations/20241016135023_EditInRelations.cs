using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class EditInRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VisitorPermissionSteps_CancelRequestId",
                table: "VisitorPermissionSteps");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorPermissionSteps_CancelRequestId",
                table: "VisitorPermissionSteps",
                column: "CancelRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VisitorPermissionSteps_CancelRequestId",
                table: "VisitorPermissionSteps");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorPermissionSteps_CancelRequestId",
                table: "VisitorPermissionSteps",
                column: "CancelRequestId",
                unique: true,
                filter: "[CancelRequestId] IS NOT NULL");
        }
    }
}
