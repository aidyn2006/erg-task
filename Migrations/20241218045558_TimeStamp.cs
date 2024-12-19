using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERG_Task.Migrations
{
    /// <inheritdoc />
    public partial class TimeStamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventIdParent",
                table: "Genealogy",
                newName: "ParentEventId");

            migrationBuilder.RenameColumn(
                name: "EventIdChild",
                table: "Genealogy",
                newName: "ChildEventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentEventId",
                table: "Genealogy",
                newName: "EventIdParent");

            migrationBuilder.RenameColumn(
                name: "ChildEventId",
                table: "Genealogy",
                newName: "EventIdChild");
        }
    }
}
