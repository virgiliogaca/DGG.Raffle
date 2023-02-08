using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DGG.Raffle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "catalog");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Charities",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaffleSessions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaffleSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaffleEntries",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RaffleSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CharityId = table.Column<int>(type: "int", nullable: false),
                    ChatterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatterMovie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoneyDonated = table.Column<double>(type: "float", nullable: false),
                    isRaffleWinner = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaffleEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaffleEntries_Charities_CharityId",
                        column: x => x.CharityId,
                        principalSchema: "catalog",
                        principalTable: "Charities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaffleEntries_RaffleSessions_RaffleSessionId",
                        column: x => x.RaffleSessionId,
                        principalSchema: "dbo",
                        principalTable: "RaffleSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "Charities",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[] { 1, null, new DateTime(2023, 2, 8, 23, 18, 4, 165, DateTimeKind.Utc).AddTicks(400), true, null, false, "Against Malaria Foundation" });

            migrationBuilder.CreateIndex(
                name: "IX_RaffleEntries_CharityId",
                schema: "dbo",
                table: "RaffleEntries",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_RaffleEntries_RaffleSessionId",
                schema: "dbo",
                table: "RaffleEntries",
                column: "RaffleSessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaffleEntries",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Charities",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "RaffleSessions",
                schema: "dbo");
        }
    }
}
