using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UtilityPaymentManager.Migrations
{
    public partial class Changed_PaidCounter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Counters_Payments_PaymentId",
                table: "Counters");

            migrationBuilder.DropIndex(
                name: "IX_Counters_PaymentId",
                table: "Counters");

            migrationBuilder.DropColumn(
                name: "ChangeAmount",
                table: "Counters");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Counters");

            migrationBuilder.DropColumn(
                name: "PaidCounterId",
                table: "Counters");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Counters");

            migrationBuilder.CreateTable(
                name: "PaidCounters",
                columns: table => new
                {
                    PaidCounterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaidCounterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousNumber = table.Column<decimal>(type: "decimal(5,3)", nullable: false),
                    NewNumber = table.Column<decimal>(type: "decimal(5,3)", nullable: false),
                    ChangeAmount = table.Column<decimal>(type: "decimal(5,3)", nullable: false),
                    PaidCounterPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaidCounterSum = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaidCounters", x => x.PaidCounterId);
                    table.ForeignKey(
                        name: "FK_PaidCounters_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaidCounters_PaymentId",
                table: "PaidCounters",
                column: "PaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaidCounters");

            migrationBuilder.AddColumn<decimal>(
                name: "ChangeAmount",
                table: "Counters",
                type: "decimal(5,3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Counters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PaidCounterId",
                table: "Counters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Counters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Counters_PaymentId",
                table: "Counters",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Counters_Payments_PaymentId",
                table: "Counters",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId");
        }
    }
}
