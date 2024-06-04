using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechStoreManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57f252e8-a7f5-47c5-a461-c6ef6ed80523", "AQAAAAIAAYagAAAAEDjjoODiDK2Ndvey8JkuyrfStdgtQmajDKymLSi5PM3K4VOn6OzXwqp+WrnA6vQckw==", "2dabc56e-7f28-47d7-bdba-a890210cdb4b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64043554-7bbf-4e8d-bd3e-f7059c4c8f3f", "AQAAAAIAAYagAAAAEKLAG/m8h+P/l5O3/zcKa8jqRsxC5Vn6uIykaBqw+4FFyNpJwc/NCk3OTOLqGTF55w==", "6aed815f-22a3-4259-98f3-6acb02902f41" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "DateCreated", "DateModified", "Location", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 4, 11, 56, 8, 630, DateTimeKind.Local).AddTicks(9810), new DateTime(2024, 6, 4, 11, 56, 8, 630, DateTimeKind.Local).AddTicks(9900), "Kyiv", "Rozetka" },
                    { 2, new DateTime(2024, 6, 4, 11, 56, 8, 630, DateTimeKind.Local).AddTicks(9900), new DateTime(2024, 6, 4, 11, 56, 8, 630, DateTimeKind.Local).AddTicks(9900), "Lviv", "Hotline" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1778a10a-f307-451b-973e-ede92c0e0f33", "AQAAAAIAAYagAAAAEOhIIyu7D5mCgU4v1v76VzISTW1CICSdm3QKAF7L/x804/KZZ++fGMbECDklG/4lcg==", "1fd0b6f7-0a38-4abd-87b8-cd0b8cd2941e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75e7f8fc-7643-45d5-94a3-1c7c83c7ab8d", "AQAAAAIAAYagAAAAEPuiJJX2cO1xooCWwDO0lJYU/UEvRe0mmaOp5XOEpmkzpI9RPUrjfhQs6ftr1jfiUw==", "68e6dd11-1d89-4d8b-b454-0913f8039636" });
        }
    }
}
