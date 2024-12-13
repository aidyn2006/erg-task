using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERG_Task.Migrations
{
    /// <inheritdoc />
    public partial class AddAutoIncrementPrimaryKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EventId1",
                table: "EventHistories",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventHistories_EventId1",
                table: "EventHistories",
                column: "EventId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EventHistories_Events_EventId1",
                table: "EventHistories",
                column: "EventId1",
                principalTable: "Events",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventHistories_Events_EventId1",
                table: "EventHistories");

            migrationBuilder.DropIndex(
                name: "IX_EventHistories_EventId1",
                table: "EventHistories");

            migrationBuilder.DropColumn(
                name: "EventId1",
                table: "EventHistories");
        }
    }
}
