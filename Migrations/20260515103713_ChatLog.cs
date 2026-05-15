using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KaardiManguProject.Migrations
{
    /// <inheritdoc />
    public partial class ChatLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatLog",
                columns: table => new
                {
                    MessageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatLog", x => x.MessageID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatLog");
        }
    }
}
