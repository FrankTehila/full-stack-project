using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    firstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    leaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__3214EC07227DB59F", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumOfSeats = table.Column<int>(type: "int", nullable: false),
                    NumOfComputers = table.Column<int>(type: "int", nullable: false),
                    IsProjector = table.Column<bool>(type: "bit", nullable: false),
                    IsBoard = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__3214EC07F185C933", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamLeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    numOfWorkers = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    firstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TeamLead__3214EC0707B20BA5", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    roomId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    startTime = table.Column<TimeOnly>(type: "time(0)", precision: 0, nullable: false),
                    duration = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    leaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__3214EC07B0C2164B", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Meeting__leaderI__68487DD7",
                        column: x => x.leaderId,
                        principalTable: "TeamLeader",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Meeting__roomId__693CA210",
                        column: x => x.roomId,
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_leaderId",
                table: "Meeting",
                column: "leaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_roomId",
                table: "Meeting",
                column: "roomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "TeamLeader");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
