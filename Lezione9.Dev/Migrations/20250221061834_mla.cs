using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lezione9.Dev.Migrations
{
    /// <inheritdoc />
    public partial class mla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GiornoGiornaliera_Cities_CityId",
                table: "GiornoGiornaliera");

            migrationBuilder.DropForeignKey(
                name: "FK_GiornoGiornaliera_Previsioni_GiornoId",
                table: "GiornoGiornaliera");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GiornoGiornaliera",
                table: "GiornoGiornaliera");

            migrationBuilder.RenameTable(
                name: "GiornoGiornaliera",
                newName: "PrevisioneGiornalieras");

            migrationBuilder.RenameIndex(
                name: "IX_GiornoGiornaliera_GiornoId",
                table: "PrevisioneGiornalieras",
                newName: "IX_PrevisioneGiornalieras_GiornoId");

            migrationBuilder.RenameIndex(
                name: "IX_GiornoGiornaliera_CityId",
                table: "PrevisioneGiornalieras",
                newName: "IX_PrevisioneGiornalieras_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrevisioneGiornalieras",
                table: "PrevisioneGiornalieras",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrevisioneGiornalieras_Cities_CityId",
                table: "PrevisioneGiornalieras",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrevisioneGiornalieras_Previsioni_GiornoId",
                table: "PrevisioneGiornalieras",
                column: "GiornoId",
                principalTable: "Previsioni",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrevisioneGiornalieras_Cities_CityId",
                table: "PrevisioneGiornalieras");

            migrationBuilder.DropForeignKey(
                name: "FK_PrevisioneGiornalieras_Previsioni_GiornoId",
                table: "PrevisioneGiornalieras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrevisioneGiornalieras",
                table: "PrevisioneGiornalieras");

            migrationBuilder.RenameTable(
                name: "PrevisioneGiornalieras",
                newName: "GiornoGiornaliera");

            migrationBuilder.RenameIndex(
                name: "IX_PrevisioneGiornalieras_GiornoId",
                table: "GiornoGiornaliera",
                newName: "IX_GiornoGiornaliera_GiornoId");

            migrationBuilder.RenameIndex(
                name: "IX_PrevisioneGiornalieras_CityId",
                table: "GiornoGiornaliera",
                newName: "IX_GiornoGiornaliera_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GiornoGiornaliera",
                table: "GiornoGiornaliera",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GiornoGiornaliera_Cities_CityId",
                table: "GiornoGiornaliera",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GiornoGiornaliera_Previsioni_GiornoId",
                table: "GiornoGiornaliera",
                column: "GiornoId",
                principalTable: "Previsioni",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
