using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentRegistrationSystem.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Dtatime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfRegistration",
                table: "Students",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfRegistration",
                table: "Students");
        }
    }
}
