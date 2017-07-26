using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairbookWebApi.Migrations
{
    public partial class Migration9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriend_User_FriendId",
                table: "UserFriend");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriend_User_UserId",
                table: "UserFriend");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_UserFriend_UserId_FriendId",
                table: "UserFriend");

            migrationBuilder.DropIndex(
                name: "IX_UserFriend_FriendId",
                table: "UserFriend");

            migrationBuilder.DropColumn(
                name: "IsFriend",
                table: "UserFriend");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserFriend",
                newName: "UserTwoId");

            migrationBuilder.RenameColumn(
                name: "FriendId",
                table: "UserFriend",
                newName: "UserOneId");

            migrationBuilder.AddColumn<int>(
                name: "FriendType",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "UserTwoId",
                table: "UserFriend",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserOneId",
                table: "UserFriend",
                newName: "FriendId");

            migrationBuilder.AddColumn<bool>(
                name: "IsFriend",
                table: "UserFriend",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UserFriend_UserId_FriendId",
                table: "UserFriend",
                columns: new[] { "UserId", "FriendId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserFriend_FriendId",
                table: "UserFriend",
                column: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriend_User_FriendId",
                table: "UserFriend",
                column: "FriendId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriend_User_UserId",
                table: "UserFriend",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
