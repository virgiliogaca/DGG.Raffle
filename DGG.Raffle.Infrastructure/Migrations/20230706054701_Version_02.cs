using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DGG.Raffle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Version02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaffleEntries_RaffleSessions_RaffleSessionId",
                schema: "dbo",
                table: "RaffleEntries");

            migrationBuilder.DropTable(
                name: "RaffleSessions",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_RaffleEntries_RaffleSessionId",
                schema: "dbo",
                table: "RaffleEntries");

            migrationBuilder.DropColumn(
                name: "RaffleSessionId",
                schema: "dbo",
                table: "RaffleEntries");

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "Charities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 6, 5, 47, 1, 230, DateTimeKind.Utc).AddTicks(1426));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RaffleSessionId",
                schema: "dbo",
                table: "RaffleEntries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "RaffleSessions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaffleSessions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "Charities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 9, 0, 8, 36, 546, DateTimeKind.Utc).AddTicks(4433));

            migrationBuilder.CreateIndex(
                name: "IX_RaffleEntries_RaffleSessionId",
                schema: "dbo",
                table: "RaffleEntries",
                column: "RaffleSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RaffleEntries_RaffleSessions_RaffleSessionId",
                schema: "dbo",
                table: "RaffleEntries",
                column: "RaffleSessionId",
                principalSchema: "dbo",
                principalTable: "RaffleSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
