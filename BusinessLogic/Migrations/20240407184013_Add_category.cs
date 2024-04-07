using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BusinessLogic.Migrations
{
    /// <inheritdoc />
    public partial class Add_category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "tb_vent",
                newName: "CategoryId");

            migrationBuilder.CreateTable(
                name: "tb_category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_vent_CategoryId",
                table: "tb_vent",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vent_tb_category_CategoryId",
                table: "tb_vent",
                column: "CategoryId",
                principalTable: "tb_category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_vent_tb_category_CategoryId",
                table: "tb_vent");

            migrationBuilder.DropTable(
                name: "tb_category");

            migrationBuilder.DropIndex(
                name: "IX_tb_vent_CategoryId",
                table: "tb_vent");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "tb_vent",
                newName: "Category");
        }
    }
}
