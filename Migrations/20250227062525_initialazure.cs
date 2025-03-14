using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class initialazure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inquiries_Cars_CarsId",
                table: "Inquiries");

            migrationBuilder.DropIndex(
                name: "IX_Inquiries_CarsId",
                table: "Inquiries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_CarsId",
                table: "Inquiries",
                column: "CarsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inquiries_Cars_CarsId",
                table: "Inquiries",
                column: "CarsId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
