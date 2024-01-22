using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RegularUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e3a9c9e9-9be6-4c30-83f5-a17d9b1318d6", "b27ebbe9-0a70-4dd1-958f-59f7ac4d9030" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3a9c9e9-9be6-4c30-83f5-a17d9b1318d6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b27ebbe9-0a70-4dd1-958f-59f7ac4d9030");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c09b0080-d72c-40bd-89d0-44472bcadd2c", "c09b0080-d72c-40bd-89d0-44472bcadd2c", "admin", "ADMIN" },
                    { "d96ede64-ed4d-4a20-b572-cd6ad989b8ce", "d96ede64-ed4d-4a20-b572-cd6ad989b8ce", "regular", "REGULAR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "92a90e7a-38d2-4c40-92ef-1ecdebad5910", 0, "2c188cef-73f1-4cdb-b149-1306fa688e7b", "pudzian@wsei.edu.pl", true, false, null, "PUDZIAN@WSEI.EDU.PL", null, "AQAAAAEAACcQAAAAEK9jfiN0yben4cBn0EKxFhXgcanWStMqHzI8h0a3AGplXWgpevAxi8a5SXMVecW/ZQ==", null, false, "c67b62b0-9218-4f78-b80a-fc485c057a15", false, "pudzian" },
                    { "b3d87baa-6b05-42f0-a8fe-7d91f9952a3e", 0, "a7657e68-c257-41fd-bab8-64aa84d62ba4", "user@wsei.edu.pl", true, false, null, "USER@WSEI.EDU.PL", null, "AQAAAAEAACcQAAAAEKci4KjsMzXYXi8Edcz1g7YFwDFaXfZ0yTXjgIEjREhQtdlZvGUgjWeHbpIkE7JTrA==", null, false, "8b9467df-3f48-45fa-b33f-3ae39fb98d98", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c09b0080-d72c-40bd-89d0-44472bcadd2c", "92a90e7a-38d2-4c40-92ef-1ecdebad5910" },
                    { "d96ede64-ed4d-4a20-b572-cd6ad989b8ce", "b3d87baa-6b05-42f0-a8fe-7d91f9952a3e" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c09b0080-d72c-40bd-89d0-44472bcadd2c", "92a90e7a-38d2-4c40-92ef-1ecdebad5910" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d96ede64-ed4d-4a20-b572-cd6ad989b8ce", "b3d87baa-6b05-42f0-a8fe-7d91f9952a3e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c09b0080-d72c-40bd-89d0-44472bcadd2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d96ede64-ed4d-4a20-b572-cd6ad989b8ce");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92a90e7a-38d2-4c40-92ef-1ecdebad5910");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3d87baa-6b05-42f0-a8fe-7d91f9952a3e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3a9c9e9-9be6-4c30-83f5-a17d9b1318d6", "e3a9c9e9-9be6-4c30-83f5-a17d9b1318d6", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b27ebbe9-0a70-4dd1-958f-59f7ac4d9030", 0, "7d54ec72-69c5-4551-9882-1f76c7df8c42", "pudzian@wsei.edu.pl", true, false, null, "PUDZIAN@WSEI.EDU.PL", null, "AQAAAAEAACcQAAAAEF5lDZqKV86n5nKPFiLUeDi+Bv8+VnzDSpCCTdb9DVwq+LiJJQicC9Vqg741E7bKtw==", null, false, "c2da7ba8-03bb-4890-aa97-f3581a7bad34", false, "pudzian@wsei.edu.pl" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e3a9c9e9-9be6-4c30-83f5-a17d9b1318d6", "b27ebbe9-0a70-4dd1-958f-59f7ac4d9030" });
        }
    }
}
