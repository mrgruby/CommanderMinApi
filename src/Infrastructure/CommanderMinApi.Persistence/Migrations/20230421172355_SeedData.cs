using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommanderMinApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "PlatformId", "PlatformDescription", "PlatformImageUrl", "PlatformName" },
                values: new object[,]
                {
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "", "", "Entity Framework" },
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "", "", "Angular CLI" },
                    { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), "", "", "Git commands" }
                });

            migrationBuilder.InsertData(
                table: "CommandLines",
                columns: new[] { "CommandLineId", "Comment", "HowTo", "Line", "PlatformId", "PlatformName" },
                values: new object[,]
                {
                    { new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"), "This is a comment", "Update database", "This is the command", new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "Entity Framework" },
                    { new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), "This is a comment", "Generate new component", "This is the command", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Angular CLI" },
                    { new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"), "This is a comment", "Add new migratation", "This is the command", new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "Entity Framework" },
                    { new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"), "This is a comment", "Add new repository", "This is the command", new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), "Git commands" },
                    { new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"), "This is a comment", "Push code", "This is the command", new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), "Git commands" },
                    { new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"), "This is a comment", "Change branch", "This is the command", new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), "Git commands" },
                    { new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"), "This is a comment", "Update packages", "This is the command", new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "Entity Framework" },
                    { new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"), "This is a comment", "Generate new Service", "This is the command", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Angular CLI" },
                    { new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"), "This is a comment", "Generate new module", "This is the command", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Angular CLI" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CommandLines",
                keyColumn: "CommandLineId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"));

            migrationBuilder.DeleteData(
                table: "CommandLines",
                keyColumn: "CommandLineId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"));

            migrationBuilder.DeleteData(
                table: "CommandLines",
                keyColumn: "CommandLineId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"));

            migrationBuilder.DeleteData(
                table: "CommandLines",
                keyColumn: "CommandLineId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"));

            migrationBuilder.DeleteData(
                table: "CommandLines",
                keyColumn: "CommandLineId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"));

            migrationBuilder.DeleteData(
                table: "CommandLines",
                keyColumn: "CommandLineId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"));

            migrationBuilder.DeleteData(
                table: "CommandLines",
                keyColumn: "CommandLineId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"));

            migrationBuilder.DeleteData(
                table: "CommandLines",
                keyColumn: "CommandLineId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"));

            migrationBuilder.DeleteData(
                table: "CommandLines",
                keyColumn: "CommandLineId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"));
        }
    }
}
