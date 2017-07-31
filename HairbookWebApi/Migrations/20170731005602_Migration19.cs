using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairbookWebApi.Migrations
{
    public partial class Migration19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorite_User_CreatedUserId",
                table: "UserFavorite");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorite_User_CreatedUserId",
                table: "UserFavorite",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorite_User_CreatedUserId",
                table: "UserFavorite");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorite_User_CreatedUserId",
                table: "UserFavorite",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
