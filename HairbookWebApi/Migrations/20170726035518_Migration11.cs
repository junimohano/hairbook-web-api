using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairbookWebApi.Migrations
{
    public partial class Migration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriend_User_CreatedUserId",
                table: "UserFriend");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriend_User_UserOneId",
                table: "UserFriend");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriend_User_UserTwoId",
                table: "UserFriend");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_UserFriend_UserOneId_UserTwoId",
                table: "UserFriend");

            migrationBuilder.DropIndex(
                name: "IX_UserFriend_UserTwoId",
                table: "UserFriend");

            migrationBuilder.DropColumn(
                name: "FriendType",
                table: "UserFriend");

            migrationBuilder.DropColumn(
                name: "UserOneId",
                table: "UserFriend");

            migrationBuilder.DropColumn(
                name: "UserTwoId",
                table: "UserFriend");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserFriend",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFriend_UserId",
                table: "UserFriend",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriend_User_CreatedUserId",
                table: "UserFriend",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriend_User_UserId",
                table: "UserFriend",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriend_User_CreatedUserId",
                table: "UserFriend");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriend_User_UserId",
                table: "UserFriend");

            migrationBuilder.DropIndex(
                name: "IX_UserFriend_UserId",
                table: "UserFriend");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserFriend");

            migrationBuilder.AddColumn<int>(
                name: "FriendType",
                table: "UserFriend",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserOneId",
                table: "UserFriend",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserTwoId",
                table: "UserFriend",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UserFriend_UserOneId_UserTwoId",
                table: "UserFriend",
                columns: new[] { "UserOneId", "UserTwoId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserFriend_UserTwoId",
                table: "UserFriend",
                column: "UserTwoId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriend_User_CreatedUserId",
                table: "UserFriend",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriend_User_UserOneId",
                table: "UserFriend",
                column: "UserOneId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriend_User_UserTwoId",
                table: "UserFriend",
                column: "UserTwoId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
