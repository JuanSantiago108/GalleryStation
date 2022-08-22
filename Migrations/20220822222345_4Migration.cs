using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalleryStation.Migrations
{
    public partial class _4Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arts_Users_UserId",
                table: "Arts");

            migrationBuilder.DropTable(
                name: "Association");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Arts",
                table: "Arts");

            migrationBuilder.RenameTable(
                name: "Arts",
                newName: "Art");

            migrationBuilder.RenameIndex(
                name: "IX_Arts_UserId",
                table: "Art",
                newName: "IX_Art_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Art",
                table: "Art",
                column: "ArtId");

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchasesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchasesId);
                    table.ForeignKey(
                        name: "FK_Purchases_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId",
                table: "Purchases",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Art_Users_UserId",
                table: "Art",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Art_Users_UserId",
                table: "Art");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Art",
                table: "Art");

            migrationBuilder.RenameTable(
                name: "Art",
                newName: "Arts");

            migrationBuilder.RenameIndex(
                name: "IX_Art_UserId",
                table: "Arts",
                newName: "IX_Arts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Arts",
                table: "Arts",
                column: "ArtId");

            migrationBuilder.CreateTable(
                name: "Association",
                columns: table => new
                {
                    AssociationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ArtId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Association", x => x.AssociationId);
                    table.ForeignKey(
                        name: "FK_Association_Arts_ArtId",
                        column: x => x.ArtId,
                        principalTable: "Arts",
                        principalColumn: "ArtId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Association_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Association_ArtId",
                table: "Association",
                column: "ArtId");

            migrationBuilder.CreateIndex(
                name: "IX_Association_UserId",
                table: "Association",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Arts_Users_UserId",
                table: "Arts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
