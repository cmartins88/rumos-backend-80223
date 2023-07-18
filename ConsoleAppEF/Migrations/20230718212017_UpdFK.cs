using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleAppEF.Migrations
{
    /// <inheritdoc />
    public partial class UpdFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Orders_ProductId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Product",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductId",
                table: "Product",
                newName: "IX_Product_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Orders_OrderId",
                table: "Product",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Orders_OrderId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Product",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_OrderId",
                table: "Product",
                newName: "IX_Product_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Orders_ProductId",
                table: "Product",
                column: "ProductId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
