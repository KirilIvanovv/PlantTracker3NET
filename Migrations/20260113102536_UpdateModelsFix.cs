using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantTracker3NET.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PlantNotes");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "PlantCareLogs");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "PlantNotes",
                newName: "NoteText");

            migrationBuilder.RenameColumn(
                name: "ActionDate",
                table: "PlantCareLogs",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "ActionTaken",
                table: "PlantCareLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionTaken",
                table: "PlantCareLogs");

            migrationBuilder.RenameColumn(
                name: "NoteText",
                table: "PlantNotes",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "PlantCareLogs",
                newName: "ActionDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PlantNotes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "PlantCareLogs",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
