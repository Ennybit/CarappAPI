using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class primarykeyininquiries5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inquiries_Cars_CarsId",
                table: "Inquiries");

            migrationBuilder.AlterColumn<int>(
                name: "CarsId",
                table: "Inquiries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inquiries_Cars_CarsId",
                table: "Inquiries",
                column: "CarsId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inquiries_Cars_CarsId",
                table: "Inquiries");

            migrationBuilder.AlterColumn<int>(
                name: "CarsId",
                table: "Inquiries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Inquiries_Cars_CarsId",
                table: "Inquiries",
                column: "CarsId",
                principalTable: "Cars",
                principalColumn: "Id");
        }
    }
}
