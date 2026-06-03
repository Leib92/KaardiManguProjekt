using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KaardiManguProject.Migrations
{
    /// <inheritdoc />
    public partial class AddFilter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filter",
                columns: table => new
                {
                    FilterID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilterData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filter", x => x.FilterID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filter");
        }
    }
}
