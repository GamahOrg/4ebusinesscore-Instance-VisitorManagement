using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertiesInSteps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReasonForCancled",
                table: "VisitorPermissionSteps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Violationtype",
                table: "VisitorPermissionSteps",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReasonForCancled",
                table: "VisitorPermissionSteps");

            migrationBuilder.DropColumn(
                name: "Violationtype",
                table: "VisitorPermissionSteps");
        }
    }
}
