using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ComputerCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1f50c62b-d8a9-4d3f-9804-1c2f808bc718", "59298c2f-bb98-47b4-9444-9ba8b4479c8a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f50c62b-d8a9-4d3f-9804-1c2f808bc718");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59298c2f-bb98-47b4-9444-9ba8b4479c8a");

            migrationBuilder.CreateTable(
                name: "computers",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CPU = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    RAM = table.Column<float>(type: "REAL", nullable: false),
                    GPU = table.Column<string>(type: "TEXT", nullable: true),
                    Manufacturer = table.Column<string>(type: "TEXT", nullable: true),
                    ProductionDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computers", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3014c079-1210-4204-804d-ba45a4058624", "3014c079-1210-4204-804d-ba45a4058624", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7ec80f3d-5c94-4c2c-82c7-a594cd50b9be", 0, "5a12f553-b16e-49a0-84a5-944b40ce230f", "pudzian@wsei.edu.pl", true, false, null, "PUDZIAN@WSEI.EDU.PL", null, "AQAAAAEAACcQAAAAEJwJ6zJ5vU6++VTjPhlroHxPiYeGIf2UjeM0RBPB+bYXevGQ19rVY0o099cZLMX54w==", null, false, "f200ee81-dcb1-49a2-be38-8d2a4eafbfdd", false, "pudzian@wsei.edu.pl" });

            migrationBuilder.InsertData(
                table: "computers",
                columns: new[] { "id", "CPU", "Created", "GPU", "Manufacturer", "Name", "ProductionDate", "RAM" },
                values: new object[,]
                {
                    { 1, "Intel Core i9-14900K", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GeForce RTX 4090", "DELL", "Gaming computer", null, 32f },
                    { 2, "Intel Core i5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HP", "Office computer", null, 8f }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3014c079-1210-4204-804d-ba45a4058624", "7ec80f3d-5c94-4c2c-82c7-a594cd50b9be" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "computers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3014c079-1210-4204-804d-ba45a4058624", "7ec80f3d-5c94-4c2c-82c7-a594cd50b9be" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3014c079-1210-4204-804d-ba45a4058624");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7ec80f3d-5c94-4c2c-82c7-a594cd50b9be");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1f50c62b-d8a9-4d3f-9804-1c2f808bc718", "1f50c62b-d8a9-4d3f-9804-1c2f808bc718", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "59298c2f-bb98-47b4-9444-9ba8b4479c8a", 0, "4697a76d-f61f-454c-aab1-d0558d69f98e", "pudzian@wsei.edu.pl", true, false, null, "PUDZIAN@WSEI.EDU.PL", null, "AQAAAAEAACcQAAAAEHKQfR2pZl/m/Gih6en2ZHsriggN4udVofagJtciASJYps2gAcKyyXM2oiy84Sj1Dg==", null, false, "bfafd76e-5fdb-4155-8a98-945d4c1774ff", false, "pudzian@wsei.edu.pl" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1f50c62b-d8a9-4d3f-9804-1c2f808bc718", "59298c2f-bb98-47b4-9444-9ba8b4479c8a" });
        }
    }
}
