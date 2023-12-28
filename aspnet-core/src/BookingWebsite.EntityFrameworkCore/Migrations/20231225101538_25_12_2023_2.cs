﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebsite.Migrations
{
    /// <inheritdoc />
    public partial class _25_12_2023_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BwHotelUnit_LocationId",
                table: "BwHotelUnit",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BwHotelUnit_BwLocation_LocationId",
                table: "BwHotelUnit",
                column: "LocationId",
                principalTable: "BwLocation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BwHotelUnit_BwLocation_LocationId",
                table: "BwHotelUnit");

            migrationBuilder.DropIndex(
                name: "IX_BwHotelUnit_LocationId",
                table: "BwHotelUnit");
        }
    }
}
