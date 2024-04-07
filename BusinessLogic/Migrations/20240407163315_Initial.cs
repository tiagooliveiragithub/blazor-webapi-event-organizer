using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BusinessLogic.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_vent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Hour = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Localization = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    MaxCapacity = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_vent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_vent_tb_user_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "tb_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_activity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Hour = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_activity_tb_vent_EventId",
                        column: x => x.EventId,
                        principalTable: "tb_vent",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Msg = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_ticket_tb_user_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "tb_user",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_ticket_tb_vent_EventId",
                        column: x => x.EventId,
                        principalTable: "tb_vent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_activity_EventId",
                table: "tb_activity",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ticket_EventId",
                table: "tb_ticket",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ticket_OwnerId",
                table: "tb_ticket",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_vent_OwnerId",
                table: "tb_vent",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_activity");

            migrationBuilder.DropTable(
                name: "tb_ticket");

            migrationBuilder.DropTable(
                name: "tb_vent");

            migrationBuilder.DropTable(
                name: "tb_user");
        }
    }
}
