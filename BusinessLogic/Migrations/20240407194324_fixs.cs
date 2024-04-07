using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLogic.Migrations
{
    /// <inheritdoc />
    public partial class fixs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tb_vent",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Hour" },
                values: new object[] { new DateTime(2024, 4, 7, 19, 43, 24, 549, DateTimeKind.Utc).AddTicks(7186), new DateTime(2024, 4, 7, 19, 43, 24, 549, DateTimeKind.Utc).AddTicks(7188) });

            migrationBuilder.UpdateData(
                table: "tb_vent",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Hour" },
                values: new object[] { new DateTime(2024, 4, 7, 19, 43, 24, 549, DateTimeKind.Utc).AddTicks(7232), new DateTime(2024, 4, 7, 19, 43, 24, 549, DateTimeKind.Utc).AddTicks(7232) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tb_vent",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Hour" },
                values: new object[] { new DateTime(2024, 4, 7, 19, 1, 36, 292, DateTimeKind.Utc).AddTicks(1756), new DateTime(2024, 4, 7, 19, 1, 36, 292, DateTimeKind.Utc).AddTicks(1757) });

            migrationBuilder.UpdateData(
                table: "tb_vent",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Hour" },
                values: new object[] { new DateTime(2024, 4, 7, 19, 1, 36, 292, DateTimeKind.Utc).AddTicks(1764), new DateTime(2024, 4, 7, 19, 1, 36, 292, DateTimeKind.Utc).AddTicks(1765) });
        }
    }
}
