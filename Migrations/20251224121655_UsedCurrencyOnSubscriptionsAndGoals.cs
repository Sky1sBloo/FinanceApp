using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceApp.Migrations
{
    /// <inheritdoc />
    public partial class UsedCurrencyOnSubscriptionsAndGoals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetAmount",
                table: "Goals");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Subscriptions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Goals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Goals");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "TargetAmount",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
