using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelactionBetweenLkSourcAndPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissionSource",
                table: "Permissions");

            migrationBuilder.AddColumn<int>(
                name: "LK_PermissionSourceId",
                table: "Permissions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_LK_PermissionSourceId",
                table: "Permissions",
                column: "LK_PermissionSourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_LK_PermissionSource_LK_PermissionSourceId",
                table: "Permissions",
                column: "LK_PermissionSourceId",
                principalTable: "LK_PermissionSource",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_LK_PermissionSource_LK_PermissionSourceId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_LK_PermissionSourceId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "LK_PermissionSourceId",
                table: "Permissions");

            migrationBuilder.AddColumn<int>(
                name: "PermissionSource",
                table: "Permissions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
