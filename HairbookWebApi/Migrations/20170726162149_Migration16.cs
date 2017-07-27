using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairbookWebApi.Migrations
{
    public partial class Migration16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriend_User_CreatedUserId",
                table: "UserFriend");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriend_User_CreatedUserId",
                table: "UserFriend",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriend_User_CreatedUserId",
                table: "UserFriend");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriend_User_CreatedUserId",
                table: "UserFriend",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
