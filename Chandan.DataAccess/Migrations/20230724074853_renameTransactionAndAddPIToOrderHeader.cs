using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abby.DataAccess.Migrations
{
    public partial class renameTransactionAndAddPIToOrderHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "pickUpTime",
                table: "OrderHeader",
                newName: "PickUpTime");

            migrationBuilder.RenameColumn(
                name: "PickUpName",
                table: "OrderHeader",
                newName: "PickupName");

            migrationBuilder.RenameColumn(
                name: "Phonenumber",
                table: "OrderHeader",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "OrderHeader",
                newName: "SessionId");

            migrationBuilder.AddColumn<string>(
                name: "PaymentIntentId",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentIntentId",
                table: "OrderHeader");

            migrationBuilder.RenameColumn(
                name: "PickupName",
                table: "OrderHeader",
                newName: "PickUpName");

            migrationBuilder.RenameColumn(
                name: "PickUpTime",
                table: "OrderHeader",
                newName: "pickUpTime");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "OrderHeader",
                newName: "Phonenumber");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "OrderHeader",
                newName: "TransactionId");
        }
    }
}
