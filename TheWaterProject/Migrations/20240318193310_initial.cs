using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheWaterProject.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    projectId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    projectName = table.Column<string>(type: "TEXT", nullable: false),
                    programName = table.Column<string>(type: "TEXT", nullable: false),
                    projectType = table.Column<string>(type: "TEXT", nullable: true),
                    projectImpact = table.Column<int>(type: "INTEGER", nullable: false),
                    projectInstallation = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.projectId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
