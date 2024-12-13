using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERG_Task.Migrations
{
    /// <inheritdoc />
    public partial class AddGeneralJoins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TrainHistories_TrainId",
                table: "TrainHistories",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_TrainId",
                table: "Packages",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageHistories_PackageId",
                table: "PackageHistories",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHistories_InvoiceId",
                table: "InvoiceHistories",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_InvoiceId",
                table: "Events",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PackageId",
                table: "Events",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SupplyId",
                table: "Events",
                column: "SupplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Invoices_InvoiceId",
                table: "Events",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Packages_PackageId",
                table: "Events",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Supplies_SupplyId",
                table: "Events",
                column: "SupplyId",
                principalTable: "Supplies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceHistories_Invoices_InvoiceId",
                table: "InvoiceHistories",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageHistories_Packages_PackageId",
                table: "PackageHistories",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Trains_TrainId",
                table: "Packages",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainHistories_Trains_TrainId",
                table: "TrainHistories",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Invoices_InvoiceId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Packages_PackageId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Supplies_SupplyId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceHistories_Invoices_InvoiceId",
                table: "InvoiceHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageHistories_Packages_PackageId",
                table: "PackageHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Trains_TrainId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainHistories_Trains_TrainId",
                table: "TrainHistories");

            migrationBuilder.DropIndex(
                name: "IX_TrainHistories_TrainId",
                table: "TrainHistories");

            migrationBuilder.DropIndex(
                name: "IX_Packages_TrainId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_PackageHistories_PackageId",
                table: "PackageHistories");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceHistories_InvoiceId",
                table: "InvoiceHistories");

            migrationBuilder.DropIndex(
                name: "IX_Events_InvoiceId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_PackageId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_SupplyId",
                table: "Events");
        }
    }
}
