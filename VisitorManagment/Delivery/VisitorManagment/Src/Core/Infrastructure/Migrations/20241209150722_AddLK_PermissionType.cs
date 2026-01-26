using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class AddLK_PermissionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LK_PermissionTypeId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LK_PermissionType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LK_PermissionType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_LK_PermissionTypeId",
                table: "Permissions",
                column: "LK_PermissionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_LK_PermissionType_LK_PermissionTypeId",
                table: "Permissions",
                column: "LK_PermissionTypeId",
                principalTable: "LK_PermissionType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_LK_PermissionType_LK_PermissionTypeId",
                table: "Permissions");

            migrationBuilder.DropTable(
                name: "LK_PermissionType");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_LK_PermissionTypeId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "LK_PermissionTypeId",
                table: "Permissions");
        }
    }
}
