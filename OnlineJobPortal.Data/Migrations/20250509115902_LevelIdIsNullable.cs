using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineJobPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class LevelIdIsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_info_skills_info_levels_level_id",
                schema: "info",
                table: "info_skills");

            migrationBuilder.AlterColumn<int>(
                name: "level_id",
                schema: "info",
                table: "info_skills",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_info_skills_info_levels_level_id",
                schema: "info",
                table: "info_skills",
                column: "level_id",
                principalSchema: "info",
                principalTable: "info_levels",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_info_skills_info_levels_level_id",
                schema: "info",
                table: "info_skills");

            migrationBuilder.AlterColumn<int>(
                name: "level_id",
                schema: "info",
                table: "info_skills",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_info_skills_info_levels_level_id",
                schema: "info",
                table: "info_skills",
                column: "level_id",
                principalSchema: "info",
                principalTable: "info_levels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
