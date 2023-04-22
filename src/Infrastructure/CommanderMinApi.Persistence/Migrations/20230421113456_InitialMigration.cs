using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommanderMinApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    PlatformId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlatformName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.PlatformId);
                });

            migrationBuilder.CreateTable(
                name: "CommandLines",
                columns: table => new
                {
                    CommandLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HowTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandLines", x => x.CommandLineId);
                    table.ForeignKey(
                        name: "FK_CommandLines_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "PlatformId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommandLines_PlatformId",
                table: "CommandLines",
                column: "PlatformId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandLines");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
