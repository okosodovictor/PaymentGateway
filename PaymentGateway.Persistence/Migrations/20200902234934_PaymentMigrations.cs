using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentGateway.Persistence.Migrations
{
    public partial class PaymentMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    MerchantId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    MerchantName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AcquirerBank = table.Column<string>(nullable: true),
                    MerchantIdentificationNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.MerchantId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Reference = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Currency = table.Column<string>(maxLength: 3, nullable: true),
                    CardHolderName = table.Column<string>(maxLength: 60, nullable: true),
                    CardNumber = table.Column<string>(maxLength: 16, nullable: true),
                    ExpiryMonth = table.Column<string>(maxLength: 2, nullable: true),
                    ExpiryYear = table.Column<string>(maxLength: 2, nullable: true),
                    Cvv = table.Column<string>(maxLength: 3, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    MerchantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "MerchantId", "AcquirerBank", "Description", "MerchantIdentificationNumber", "MerchantName" },
                values: new object[] { new Guid("13f34b5e-26a6-4eef-b3cc-a247b5862fc5"), "BNF", "Online shop for Mac", "51f46cab-2935-4087-bee6-74531c6404a1", "Apple" });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "MerchantId", "AcquirerBank", "Description", "MerchantIdentificationNumber", "MerchantName" },
                values: new object[] { new Guid("9466acb3-26ad-464d-8152-bbbf20c442c4"), "BOV", "Online shop for all Items", "b29bc180-e700-433a-b484-37276658e5db", "Amazon" });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MerchantId",
                table: "Payments",
                column: "MerchantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Merchants");
        }
    }
}
