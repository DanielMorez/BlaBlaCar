using Microsoft.EntityFrameworkCore.Migrations;

namespace BlaBlaCar.Migrations
{
    public partial class BookRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRoutes_Routes_RouteId",
                table: "BookRoutes");

            migrationBuilder.DropIndex(
                name: "IX_BookRoutes_RouteId",
                table: "BookRoutes");

            migrationBuilder.AlterColumn<long>(
                name: "RouteId",
                table: "BookRoutes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "RouteId",
                table: "BookRoutes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_BookRoutes_RouteId",
                table: "BookRoutes",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRoutes_Routes_RouteId",
                table: "BookRoutes",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
