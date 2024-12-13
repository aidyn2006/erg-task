using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERG_Task.Migrations
{
    /// <inheritdoc />
    public partial class AddGenealogyJoin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EventChildId",
                table: "Genealogy",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "EventParentId",
                table: "Genealogy",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Genealogy_EventChildId",
                table: "Genealogy",
                column: "EventChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Genealogy_EventParentId",
                table: "Genealogy",
                column: "EventParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genealogy_Events_EventChildId",
                table: "Genealogy",
                column: "EventChildId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Genealogy_Events_EventParentId",
                table: "Genealogy",
                column: "EventParentId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genealogy_Events_EventChildId",
                table: "Genealogy");

            migrationBuilder.DropForeignKey(
                name: "FK_Genealogy_Events_EventParentId",
                table: "Genealogy");

            migrationBuilder.DropIndex(
                name: "IX_Genealogy_EventChildId",
                table: "Genealogy");

            migrationBuilder.DropIndex(
                name: "IX_Genealogy_EventParentId",
                table: "Genealogy");

            migrationBuilder.DropColumn(
                name: "EventChildId",
                table: "Genealogy");

            migrationBuilder.DropColumn(
                name: "EventParentId",
                table: "Genealogy");
        }
    }
}
