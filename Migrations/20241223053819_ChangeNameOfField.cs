using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERG_Task.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameOfField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Events_InvoiceId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_PackageId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_SupplyId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "SupplyId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceIdId",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackageIdId",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupplyIdId",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Events_InvoiceIdId",
                table: "Events",
                column: "InvoiceIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PackageIdId",
                table: "Events",
                column: "PackageIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SupplyIdId",
                table: "Events",
                column: "SupplyIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Invoices_InvoiceIdId",
                table: "Events",
                column: "InvoiceIdId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Packages_PackageIdId",
                table: "Events",
                column: "PackageIdId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Supplies_SupplyIdId",
                table: "Events",
                column: "SupplyIdId",
                principalTable: "Supplies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Invoices_InvoiceIdId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Packages_PackageIdId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Supplies_SupplyIdId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_InvoiceIdId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_PackageIdId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_SupplyIdId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "InvoiceIdId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PackageIdId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "SupplyIdId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Events",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "Events",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplyId",
                table: "Events",
                type: "integer",
                nullable: true);

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
        }
    }
}
