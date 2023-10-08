using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UA.Data.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddedPasswordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RolesId",
                table: "UserRole");

            migrationBuilder.RenameColumn(
                name: "RolesId",
                table: "UserRole",
                newName: "RoleId");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Age", "Email", "Name", "PasswordHash" },
                values: new object[] { new Guid("4166924c-0ff7-4028-9b56-3c590eaeabcf"), 25, "admin@example.com", "admin", "fc063b5c2ad541510b5e178a237d975dd4bbc74acf10f03d1a1fd901be6581945d53da7ce4b42c6baa0499015d64689cf5d578f37c0106ed7c9d10564869b8b6" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 0, new Guid("4166924c-0ff7-4028-9b56-3c590eaeabcf") },
                    { 1, new Guid("4166924c-0ff7-4028-9b56-3c590eaeabcf") },
                    { 2, new Guid("4166924c-0ff7-4028-9b56-3c590eaeabcf") },
                    { 3, new Guid("4166924c-0ff7-4028-9b56-3c590eaeabcf") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Role_RoleId",
                table: "UserRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RoleId",
                table: "UserRole");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 0, new Guid("4166924c-0ff7-4028-9b56-3c590eaeabcf") });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, new Guid("4166924c-0ff7-4028-9b56-3c590eaeabcf") });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, new Guid("4166924c-0ff7-4028-9b56-3c590eaeabcf") });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, new Guid("4166924c-0ff7-4028-9b56-3c590eaeabcf") });

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4166924c-0ff7-4028-9b56-3c590eaeabcf"));

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserRole",
                newName: "RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Role_RolesId",
                table: "UserRole",
                column: "RolesId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
