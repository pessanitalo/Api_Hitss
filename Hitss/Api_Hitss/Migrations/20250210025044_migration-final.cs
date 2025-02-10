using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Hitss.Migrations
{
    /// <inheritdoc />
    public partial class migrationfinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentFlowSummary",
                columns: table => new
                {
                    PaymentFlowSummary_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthlyPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentFlowSummary", x => x.PaymentFlowSummary_Id);
                });

            migrationBuilder.CreateTable(
                name: "Proposta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnnualInterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberOfMonths = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentSchedule",
                columns: table => new
                {
                    PaymentSchedule_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentFlowSummary_Id = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Principal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Interest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSchedule", x => x.PaymentSchedule_Id);
                    table.ForeignKey(
                        name: "FK_PaymentSchedule_PaymentFlowSummary_PaymentFlowSummary_Id",
                        column: x => x.PaymentFlowSummary_Id,
                        principalTable: "PaymentFlowSummary",
                        principalColumn: "PaymentFlowSummary_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSchedule_PaymentFlowSummary_Id",
                table: "PaymentSchedule",
                column: "PaymentFlowSummary_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentSchedule");

            migrationBuilder.DropTable(
                name: "Proposta");

            migrationBuilder.DropTable(
                name: "PaymentFlowSummary");
        }
    }
}
