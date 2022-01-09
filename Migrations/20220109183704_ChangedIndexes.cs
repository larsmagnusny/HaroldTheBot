using Microsoft.EntityFrameworkCore.Migrations;

namespace HaroldTheBot.Migrations
{
    public partial class ChangedIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaidParticipants_RaidEvents_RaidEventId1",
                table: "RaidParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaidParticipants",
                table: "RaidParticipants");

            migrationBuilder.DropIndex(
                name: "IX_RaidParticipants_RaidEventId1",
                table: "RaidParticipants");

            migrationBuilder.DropColumn(
                name: "RaidEventId1",
                table: "RaidParticipants");

            migrationBuilder.AlterColumn<ulong>(
                name: "RaidEventId",
                table: "RaidParticipants",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaidParticipants",
                table: "RaidParticipants",
                columns: new[] { "RaidEventId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RaidParticipants_RaidEvents_RaidEventId",
                table: "RaidParticipants",
                column: "RaidEventId",
                principalTable: "RaidEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaidParticipants_RaidEvents_RaidEventId",
                table: "RaidParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaidParticipants",
                table: "RaidParticipants");

            migrationBuilder.AlterColumn<ulong>(
                name: "RaidEventId",
                table: "RaidParticipants",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<ulong>(
                name: "RaidEventId1",
                table: "RaidParticipants",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaidParticipants",
                table: "RaidParticipants",
                column: "RaidEventId");

            migrationBuilder.CreateIndex(
                name: "IX_RaidParticipants_RaidEventId1",
                table: "RaidParticipants",
                column: "RaidEventId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RaidParticipants_RaidEvents_RaidEventId1",
                table: "RaidParticipants",
                column: "RaidEventId1",
                principalTable: "RaidEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
