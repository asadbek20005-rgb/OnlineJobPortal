using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineJobPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class SomeUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Logs",
                table: "Logs");

            migrationBuilder.RenameTable(
                name: "Logs",
                newName: "logs",
                newSchema: "application");

            migrationBuilder.RenameColumn(
                name: "Path",
                schema: "application",
                table: "logs",
                newName: "path");

            migrationBuilder.RenameColumn(
                name: "Method",
                schema: "application",
                table: "logs",
                newName: "method");

            migrationBuilder.RenameColumn(
                name: "Message",
                schema: "application",
                table: "logs",
                newName: "message");

            migrationBuilder.RenameColumn(
                name: "Level",
                schema: "application",
                table: "logs",
                newName: "level");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "application",
                table: "logs",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "StatusCode",
                schema: "application",
                table: "logs",
                newName: "status_code");

            migrationBuilder.AlterColumn<int>(
                name: "status_code",
                schema: "application",
                table: "logs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_logs",
                schema: "application",
                table: "logs",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_logs",
                schema: "application",
                table: "logs");

            migrationBuilder.RenameTable(
                name: "logs",
                schema: "application",
                newName: "Logs");

            migrationBuilder.RenameColumn(
                name: "path",
                table: "Logs",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "method",
                table: "Logs",
                newName: "Method");

            migrationBuilder.RenameColumn(
                name: "message",
                table: "Logs",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "level",
                table: "Logs",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Logs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "status_code",
                table: "Logs",
                newName: "StatusCode");

            migrationBuilder.AlterColumn<int>(
                name: "StatusCode",
                table: "Logs",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logs",
                table: "Logs",
                column: "Id");
        }
    }
}
