using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineJobPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class IChangedSomeProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_info_cities_city_id",
                schema: "application",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_info_statuses_status_id",
                schema: "application",
                table: "users");

            migrationBuilder.AlterColumn<int>(
                name: "status_id",
                schema: "application",
                table: "users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "full_name",
                schema: "application",
                table: "users",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "city_id",
                schema: "application",
                table: "users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_users_info_cities_city_id",
                schema: "application",
                table: "users",
                column: "city_id",
                principalSchema: "info",
                principalTable: "info_cities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_info_statuses_status_id",
                schema: "application",
                table: "users",
                column: "status_id",
                principalSchema: "info",
                principalTable: "info_statuses",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_info_cities_city_id",
                schema: "application",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_info_statuses_status_id",
                schema: "application",
                table: "users");

            migrationBuilder.AlterColumn<int>(
                name: "status_id",
                schema: "application",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "full_name",
                schema: "application",
                table: "users",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "city_id",
                schema: "application",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_users_info_cities_city_id",
                schema: "application",
                table: "users",
                column: "city_id",
                principalSchema: "info",
                principalTable: "info_cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_info_statuses_status_id",
                schema: "application",
                table: "users",
                column: "status_id",
                principalSchema: "info",
                principalTable: "info_statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
