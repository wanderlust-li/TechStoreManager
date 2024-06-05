using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechStoreManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "53a9fa62-d487-4121-928a-aefd19b33020", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEL06ie1UbKVi83gNoGstmsmJaoZ4LCKTDP6zBBM6b0qVtDLGsE6dVyCe42BSWO5EQw==", null, false, "95679443-63a0-48fa-b0c5-9da5172284c8", false, "admin@localhost.com" },
                    { "9e224968-33e4-4652-b7b7-8574d048cdb9", 0, "bc9ac32f-3586-482c-b3d8-a586dd8cc7d0", "user@localhost.com", true, false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEFgd8/kuONV32BlKdR9qIle8Pq1x3E+xbCSsr4QH4N3Wg+28zfS1K6RqdZ4/r+iZ3g==", null, false, "3fb8b8fe-0c2a-47bb-a7d7-4bdda2c605f6", false, "user@localhost.com" }
                });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 6, 5, 11, 17, 8, 424, DateTimeKind.Local).AddTicks(1250), new DateTime(2024, 6, 5, 11, 17, 8, 424, DateTimeKind.Local).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 6, 5, 11, 17, 8, 424, DateTimeKind.Local).AddTicks(1260), new DateTime(2024, 6, 5, 11, 17, 8, 424, DateTimeKind.Local).AddTicks(1260) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 6, 5, 11, 11, 57, 850, DateTimeKind.Local).AddTicks(6610), new DateTime(2024, 6, 5, 11, 11, 57, 850, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 6, 5, 11, 11, 57, 850, DateTimeKind.Local).AddTicks(6620), new DateTime(2024, 6, 5, 11, 11, 57, 850, DateTimeKind.Local).AddTicks(6620) });
        }
    }
}
