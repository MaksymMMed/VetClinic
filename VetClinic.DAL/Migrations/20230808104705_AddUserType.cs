using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUserType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "AspNetUsers",
                newName: "UserType");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "AnimalKind", "AnimalSex", "Description", "Name", "OwnerId" },
                values: new object[] { "125cdfba-e37f-47fb-ab74-19b09bd278c8", 2, (byte)1, (byte)1, "-", "Catalina", "2" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 8, 8, 15, 47, 5, 162, DateTimeKind.Local).AddTicks(9945), new DateTime(2023, 8, 8, 13, 47, 5, 162, DateTimeKind.Local).AddTicks(9888) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: "125cdfba-e37f-47fb-ab74-19b09bd278c8");

            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "AspNetUsers",
                newName: "Discriminator");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "AnimalKind", "AnimalSex", "Description", "Name", "OwnerId" },
                values: new object[] { "1", 2, (byte)1, (byte)1, "-", "Catalina", "2" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 7, 28, 16, 6, 48, 700, DateTimeKind.Local).AddTicks(3389), new DateTime(2023, 7, 28, 14, 6, 48, 700, DateTimeKind.Local).AddTicks(3329) });
        }
    }
}
