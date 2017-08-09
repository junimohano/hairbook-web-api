using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HairbookWebApi.Migrations
{
    public partial class Migration28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostCommentTag");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Post",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Post");

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    PostCommentId = table.Column<int>(nullable: true),
                    TagName = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_Tag_User_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tag_PostComment_PostCommentId",
                        column: x => x.PostCommentId,
                        principalTable: "PostComment",
                        principalColumn: "PostCommentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tag_User_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostCommentTag",
                columns: table => new
                {
                    PostCommentTagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    PostCommentId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCommentTag", x => x.PostCommentTagId);
                    table.ForeignKey(
                        name: "FK_PostCommentTag_User_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostCommentTag_PostComment_PostCommentId",
                        column: x => x.PostCommentId,
                        principalTable: "PostComment",
                        principalColumn: "PostCommentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCommentTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCommentTag_User_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentTag_CreatedUserId",
                table: "PostCommentTag",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentTag_PostCommentId",
                table: "PostCommentTag",
                column: "PostCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentTag_TagId",
                table: "PostCommentTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentTag_UpdatedUserId",
                table: "PostCommentTag",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_CreatedUserId",
                table: "Tag",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_PostCommentId",
                table: "Tag",
                column: "PostCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_UpdatedUserId",
                table: "Tag",
                column: "UpdatedUserId");
        }
    }
}
