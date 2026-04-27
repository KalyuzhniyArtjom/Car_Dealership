using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_Dealership.Migrations
{
    /// <inheritdoc />
    public partial class BS2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_BrandCars_BrandCarId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "BrandCarId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_BrandCars_BrandCarId",
                table: "Cars",
                column: "BrandCarId",
                principalTable: "BrandCars",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_BrandCars_BrandCarId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "BrandCarId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_BrandCars_BrandCarId",
                table: "Cars",
                column: "BrandCarId",
                principalTable: "BrandCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
