using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStop.API.Migrations
{
    /// <inheritdoc />
    public partial class Id_PropertyName_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Account_AccountID",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "Order",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "Order",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_AccountID",
                table: "Order",
                newName: "IX_Order_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Account_AccountId",
                table: "Order",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Account_AccountId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Order",
                newName: "AccountID");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Order",
                newName: "OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_AccountId",
                table: "Order",
                newName: "IX_Order_AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Account_AccountID",
                table: "Order",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
