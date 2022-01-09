using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HaroldTheBot.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaidEvents",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChannelId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    EventStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Notified = table.Column<bool>(type: "INTEGER", nullable: false),
                    Expired = table.Column<bool>(type: "INTEGER", nullable: false),
                    TankLimit = table.Column<int>(type: "INTEGER", nullable: false),
                    DPSLimit = table.Column<int>(type: "INTEGER", nullable: false),
                    HealerLimit = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaidEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaidParticipants",
                columns: table => new
                {
                    RaidEventId = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobId = table.Column<int>(type: "INTEGER", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    RaidEventId1 = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaidParticipants", x => x.RaidEventId);
                    table.ForeignKey(
                        name: "FK_RaidParticipants_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaidParticipants_RaidEvents_RaidEventId1",
                        column: x => x.RaidEventId1,
                        principalTable: "RaidEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaidParticipants_JobId",
                table: "RaidParticipants",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_RaidParticipants_RaidEventId1",
                table: "RaidParticipants",
                column: "RaidEventId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaidParticipants");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "RaidEvents");
        }
    }
}
