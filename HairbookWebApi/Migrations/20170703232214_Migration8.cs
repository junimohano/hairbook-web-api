using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairbookWebApi.Migrations
{
    public partial class Migration8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_User_UserId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComment_User_UserId",
                table: "PostComment");

            migrationBuilder.DropForeignKey(
                name: "FK_PostCommentTag_User_UserId",
                table: "PostCommentTag");

            migrationBuilder.DropForeignKey(
                name: "FK_PostEvaluation_User_UserId",
                table: "PostEvaluation");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_PostEvaluation_PostId_UserId",
                table: "PostEvaluation");

            migrationBuilder.DropIndex(
                name: "IX_PostEvaluation_UserId",
                table: "PostEvaluation");

            migrationBuilder.DropIndex(
                name: "IX_PostCommentTag_UserId",
                table: "PostCommentTag");

            migrationBuilder.DropIndex(
                name: "IX_PostComment_UserId",
                table: "PostComment");

            migrationBuilder.DropIndex(
                name: "IX_Customer_UserId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PostEvaluation");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PostCommentTag");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PostComment");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Customer");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                table: "PostEvaluation",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PostEvaluation_PostId_CreatedUserId",
                table: "PostEvaluation",
                columns: new[] { "PostId", "CreatedUserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_PostEvaluation_PostId_CreatedUserId",
                table: "PostEvaluation");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                table: "PostEvaluation",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PostEvaluation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PostCommentTag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PostComment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PostEvaluation_PostId_UserId",
                table: "PostEvaluation",
                columns: new[] { "PostId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_PostEvaluation_UserId",
                table: "PostEvaluation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentTag_UserId",
                table: "PostCommentTag",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_UserId",
                table: "PostComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId",
                table: "Customer",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_User_UserId",
                table: "Customer",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComment_User_UserId",
                table: "PostComment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostCommentTag_User_UserId",
                table: "PostCommentTag",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostEvaluation_User_UserId",
                table: "PostEvaluation",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
