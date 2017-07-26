using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairbookWebApi.Migrations
{
    public partial class Migration12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                table: "UserFriend",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FriendId",
                table: "UserFriend",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UserFriend_FriendId_CreatedUserId",
                table: "UserFriend",
                columns: new[] { "FriendId", "CreatedUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriend_User_CreatedUserId",
                table: "UserFriend",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriend_User_FriendId",
                table: "UserFriend",
                column: "FriendId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriend_User_CreatedUserId",
                table: "UserFriend");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriend_User_FriendId",
                table: "UserFriend");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_UserFriend_FriendId_CreatedUserId",
                table: "UserFriend");

            migrationBuilder.DropColumn(
                name: "FriendId",
                table: "UserFriend");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                table: "UserFriend",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
