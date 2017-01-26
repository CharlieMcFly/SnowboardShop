using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SnowboardShop.Data.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Snowboard",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Snowboard_ApplicationUserId",
                table: "Snowboard",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Snowboard_AspNetUsers_ApplicationUserId",
                table: "Snowboard",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Snowboard_AspNetUsers_ApplicationUserId",
                table: "Snowboard");

            migrationBuilder.DropIndex(
                name: "IX_Snowboard_ApplicationUserId",
                table: "Snowboard");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Snowboard");
        }
    }
}
