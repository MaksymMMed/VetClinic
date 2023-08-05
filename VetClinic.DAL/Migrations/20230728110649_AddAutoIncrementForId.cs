using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddAutoIncrementForId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 7, 28, 16, 6, 48, 700, DateTimeKind.Local).AddTicks(3389), new DateTime(2023, 7, 28, 14, 6, 48, 700, DateTimeKind.Local).AddTicks(3329) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 7, 28, 15, 54, 15, 239, DateTimeKind.Local).AddTicks(4841), new DateTime(2023, 7, 28, 13, 54, 15, 239, DateTimeKind.Local).AddTicks(4764) });
        }
    }
}
