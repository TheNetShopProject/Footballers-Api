using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AccClub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClubName",
                table: "Fotballers");

            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "Fotballers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    League = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fotballers_ClubId",
                table: "Fotballers",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotballers_Clubs_ClubId",
                table: "Fotballers",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fotballers_Clubs_ClubId",
                table: "Fotballers");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropIndex(
                name: "IX_Fotballers_ClubId",
                table: "Fotballers");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "Fotballers");

            migrationBuilder.AddColumn<string>(
                name: "ClubName",
                table: "Fotballers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
