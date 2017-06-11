using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairbookWebApi.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_PostCommentTag_PostCommentId_UserId_TagId",
                table: "PostCommentTag");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_PostComment_PostId_UserId",
                table: "PostComment");

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentTag_PostCommentId",
                table: "PostCommentTag",
                column: "PostCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_PostId",
                table: "PostComment",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PostCommentTag_PostCommentId",
                table: "PostCommentTag");

            migrationBuilder.DropIndex(
                name: "IX_PostComment_PostId",
                table: "PostComment");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PostCommentTag_PostCommentId_UserId_TagId",
                table: "PostCommentTag",
                columns: new[] { "PostCommentId", "UserId", "TagId" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PostComment_PostId_UserId",
                table: "PostComment",
                columns: new[] { "PostId", "UserId" });
        }
    }
}
