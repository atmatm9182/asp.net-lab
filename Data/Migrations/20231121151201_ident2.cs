using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ident2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d444b6c4-0e60-4830-9878-011e70980a70", "dd52bedb-42ce-4eae-bcc2-fca88dc89163" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d444b6c4-0e60-4830-9878-011e70980a70");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dd52bedb-42ce-4eae-bcc2-fca88dc89163");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d444b6c4-0e60-4830-9878-011e70980a70", "d444b6c4-0e60-4830-9878-011e70980a70", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dd52bedb-42ce-4eae-bcc2-fca88dc89163", 0, "a66ad8cb-ce8b-4172-bfe0-7e2ddc0686e0", "pudzian@wsei.edu.pl", true, false, null, "PUDZIAN@WSEI.EDU.PL", null, "AQAAAAEAACcQAAAAEPGy6I8v0oUKKwR26tsVzTQK76n5Le8PWSKzBLC5DK0UMcwnYsKwd5s1Hud3hVrp+Q==", null, false, "5817fe6a-7b4e-4beb-ad78-53459d9378bf", false, "pudzian" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d444b6c4-0e60-4830-9878-011e70980a70", "dd52bedb-42ce-4eae-bcc2-fca88dc89163" });
        }
    }
}
