using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Car_Dealership.Migrations
{
    /// <inheritdoc />
    public partial class BranCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_BrandCar_BrandId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BrandCar",
                table: "BrandCar");

            migrationBuilder.RenameTable(
                name: "BrandCar",
                newName: "BrandCars");

            migrationBuilder.RenameColumn(
                name: "Сountry",
                table: "Cars",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Cars",
                newName: "BrandCarId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                newName: "IX_Cars_BrandCarId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BrandCars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BrandCars",
                table: "BrandCars",
                column: "Id");

            migrationBuilder.InsertData(
                table: "BrandCars",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "BMW" },
                    { 2, "Mercedes" },
                    { 3, "Audi" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_BrandCars_BrandCarId",
                table: "Cars",
                column: "BrandCarId",
                principalTable: "BrandCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_BrandCars_BrandCarId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BrandCars",
                table: "BrandCars");

            migrationBuilder.DeleteData(
                table: "BrandCars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BrandCars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BrandCars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "BrandCars",
                newName: "BrandCar");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Cars",
                newName: "Сountry");

            migrationBuilder.RenameColumn(
                name: "BrandCarId",
                table: "Cars",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_BrandCarId",
                table: "Cars",
                newName: "IX_Cars_BrandId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BrandCar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BrandCar",
                table: "BrandCar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_BrandCar_BrandId",
                table: "Cars",
                column: "BrandId",
                principalTable: "BrandCar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
