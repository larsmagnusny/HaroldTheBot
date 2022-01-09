using Microsoft.EntityFrameworkCore.Migrations;

namespace HaroldTheBot.Migrations
{
    public partial class Changed_RaidParticipant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "UserId",
                table: "RaidParticipants",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RaidParticipants");
        }
    }
}
