using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommanderMinApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changed_entity_names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Line",
                table: "CommandLines",
                newName: "CommandLine");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommandLine",
                table: "CommandLines",
                newName: "Line");
        }
    }
}
