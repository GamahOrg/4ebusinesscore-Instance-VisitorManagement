using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUniqueIndexFromViolationId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CancelRequests_ViolationId",
                table: "CancelRequests");

            migrationBuilder.CreateIndex(
                name: "IX_CancelRequests_ViolationId",
                table: "CancelRequests",
                column: "ViolationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CancelRequests_ViolationId",
                table: "CancelRequests");

            migrationBuilder.CreateIndex(
                name: "IX_CancelRequests_ViolationId",
                table: "CancelRequests",
                column: "ViolationId",
                unique: true,
                filter: "[ViolationId] IS NOT NULL");
        }
    }
}
