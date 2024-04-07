using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessLogic.Migrations
{
    /// <inheritdoc />
    public partial class Datapopulator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_vent_tb_category_CategoryId",
                table: "tb_vent");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "tb_vent",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "tb_category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Games" },
                    { 2, "Music" }
                });

            migrationBuilder.InsertData(
                table: "tb_user",
                columns: new[] { "Id", "Email", "Name", "Password", "PasswordHash", "Type" },
                values: new object[,]
                {
                    { 1, "contacto.tiagooliveira@gmail.com", "Tiago Oliveira", "tiago123456", "", 1 },
                    { 2, "eduardo@gmail.com", "Eduardo Gomes", "eduardo123456", "", 1 }
                });

            migrationBuilder.InsertData(
                table: "tb_vent",
                columns: new[] { "Id", "CategoryId", "Date", "Description", "Hour", "Localization", "MaxCapacity", "Name", "OwnerId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 7, 19, 1, 36, 292, DateTimeKind.Utc).AddTicks(1756), "Description 1", new DateTime(2024, 4, 7, 19, 1, 36, 292, DateTimeKind.Utc).AddTicks(1757), "Local 1", 100, "Event 1", 1 },
                    { 2, 2, new DateTime(2024, 4, 7, 19, 1, 36, 292, DateTimeKind.Utc).AddTicks(1764), "Description 2", new DateTime(2024, 4, 7, 19, 1, 36, 292, DateTimeKind.Utc).AddTicks(1765), "Local 2", 200, "Event 2", 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vent_tb_category_CategoryId",
                table: "tb_vent",
                column: "CategoryId",
                principalTable: "tb_category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_vent_tb_category_CategoryId",
                table: "tb_vent");

            migrationBuilder.DeleteData(
                table: "tb_vent",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tb_vent",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tb_category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tb_category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tb_user",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tb_user",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "tb_vent",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vent_tb_category_CategoryId",
                table: "tb_vent",
                column: "CategoryId",
                principalTable: "tb_category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
