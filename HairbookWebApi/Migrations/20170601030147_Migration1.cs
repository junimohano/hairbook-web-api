using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HairbookWebApi.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemoEvaluation",
                columns: table => new
                {
                    MemoEvaluationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2017, 5, 31, 23, 1, 46, 974, DateTimeKind.Local)),
                    CreatedUserId = table.Column<int>(nullable: true),
                    EvaluationType = table.Column<int>(nullable: false),
                    MemoId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoEvaluation", x => x.MemoEvaluationId);
                    table.UniqueConstraint("AK_MemoEvaluation_UserId_MemoId", x => new { x.UserId, x.MemoId });
                });

            migrationBuilder.CreateTable(
                name: "MemoTag",
                columns: table => new
                {
                    MemoTagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2017, 5, 31, 23, 1, 46, 974, DateTimeKind.Local)),
                    CreatedUserId = table.Column<int>(nullable: true),
                    MemoId = table.Column<int>(nullable: false),
                    TagName = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoTag", x => x.MemoTagId);
                    table.UniqueConstraint("AK_MemoTag_UserId_MemoId", x => new { x.UserId, x.MemoId });
                });

            migrationBuilder.CreateTable(
                name: "MemoUpload",
                columns: table => new
                {
                    MemoUploadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2017, 5, 31, 23, 1, 46, 974, DateTimeKind.Local)),
                    CreatedUserId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MemoId = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true),
                    UploadType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoUpload", x => x.MemoUploadId);
                });

            migrationBuilder.CreateTable(
                name: "PostEvaluation",
                columns: table => new
                {
                    PostEvaluationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2017, 5, 31, 23, 1, 46, 974, DateTimeKind.Local)),
                    CreatedUserId = table.Column<int>(nullable: true),
                    EvaluationType = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostEvaluation", x => x.PostEvaluationId);
                    table.UniqueConstraint("AK_PostEvaluation_UserId_PostId", x => new { x.UserId, x.PostId });
                });

            migrationBuilder.CreateTable(
                name: "PostTag",
                columns: table => new
                {
                    PostTagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2017, 5, 31, 23, 1, 46, 974, DateTimeKind.Local)),
                    CreatedUserId = table.Column<int>(nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    TagName = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => x.PostTagId);
                    table.UniqueConstraint("AK_PostTag_UserId_PostId", x => new { x.UserId, x.PostId });
                });

            migrationBuilder.CreateTable(
                name: "PostUpload",
                columns: table => new
                {
                    PostUploadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2017, 5, 31, 23, 1, 46, 975, DateTimeKind.Local)),
                    CreatedUserId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true),
                    UploadType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUpload", x => x.PostUploadId);
                });

            migrationBuilder.CreateTable(
                name: "Memo",
                columns: table => new
                {
                    MemoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessType = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2017, 5, 31, 23, 1, 46, 965, DateTimeKind.Local)),
                    CreatedUserId = table.Column<int>(nullable: true),
                    SalonId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memo", x => x.MemoId);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessType = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2017, 5, 31, 23, 1, 46, 974, DateTimeKind.Local)),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SalonId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2017, 5, 31, 23, 1, 46, 975, DateTimeKind.Local)),
                    CreatedUserId = table.Column<int>(nullable: true),
                    SalonId = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true),
                    UserKey = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.UniqueConstraint("AK_User_UserKey", x => x.UserKey);
                    table.ForeignKey(
                        name: "FK_User_User_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_User_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Salon",
                columns: table => new
                {
                    SalonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2017, 5, 31, 23, 1, 46, 975, DateTimeKind.Local)),
                    CreatedUserId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salon", x => x.SalonId);
                    table.ForeignKey(
                        name: "FK_Salon_User_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Salon_User_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFriend",
                columns: table => new
                {
                    UserFriendId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2017, 5, 31, 23, 1, 46, 975, DateTimeKind.Local)),
                    CreatedUserId = table.Column<int>(nullable: true),
                    FriendId = table.Column<int>(nullable: false),
                    IsPending = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFriend", x => x.UserFriendId);
                    table.UniqueConstraint("AK_UserFriend_UserId_FriendId", x => new { x.UserId, x.FriendId });
                    table.ForeignKey(
                        name: "FK_UserFriend_User_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFriend_User_FriendId",
                        column: x => x.FriendId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFriend_User_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFriend_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Memo_CreatedUserId",
                table: "Memo",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Memo_SalonId",
                table: "Memo",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Memo_UpdatedUserId",
                table: "Memo",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemoEvaluation_CreatedUserId",
                table: "MemoEvaluation",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemoEvaluation_MemoId",
                table: "MemoEvaluation",
                column: "MemoId");

            migrationBuilder.CreateIndex(
                name: "IX_MemoEvaluation_UpdatedUserId",
                table: "MemoEvaluation",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemoTag_CreatedUserId",
                table: "MemoTag",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemoTag_MemoId",
                table: "MemoTag",
                column: "MemoId");

            migrationBuilder.CreateIndex(
                name: "IX_MemoTag_UpdatedUserId",
                table: "MemoTag",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemoUpload_CreatedUserId",
                table: "MemoUpload",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemoUpload_MemoId",
                table: "MemoUpload",
                column: "MemoId");

            migrationBuilder.CreateIndex(
                name: "IX_MemoUpload_UpdatedUserId",
                table: "MemoUpload",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CreatedUserId",
                table: "Post",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_SalonId",
                table: "Post",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UpdatedUserId",
                table: "Post",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostEvaluation_CreatedUserId",
                table: "PostEvaluation",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostEvaluation_PostId",
                table: "PostEvaluation",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostEvaluation_UpdatedUserId",
                table: "PostEvaluation",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_CreatedUserId",
                table: "PostTag",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_PostId",
                table: "PostTag",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_UpdatedUserId",
                table: "PostTag",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUpload_CreatedUserId",
                table: "PostUpload",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUpload_PostId",
                table: "PostUpload",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUpload_UpdatedUserId",
                table: "PostUpload",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Salon_CreatedUserId",
                table: "Salon",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Salon_UpdatedUserId",
                table: "Salon",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CreatedUserId",
                table: "User",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_SalonId",
                table: "User",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UpdatedUserId",
                table: "User",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriend_CreatedUserId",
                table: "UserFriend",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriend_FriendId",
                table: "UserFriend",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriend_UpdatedUserId",
                table: "UserFriend",
                column: "UpdatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemoEvaluation_User_CreatedUserId",
                table: "MemoEvaluation",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemoEvaluation_User_UpdatedUserId",
                table: "MemoEvaluation",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemoEvaluation_User_UserId",
                table: "MemoEvaluation",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemoEvaluation_Memo_MemoId",
                table: "MemoEvaluation",
                column: "MemoId",
                principalTable: "Memo",
                principalColumn: "MemoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemoTag_User_CreatedUserId",
                table: "MemoTag",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemoTag_User_UpdatedUserId",
                table: "MemoTag",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemoTag_User_UserId",
                table: "MemoTag",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemoTag_Memo_MemoId",
                table: "MemoTag",
                column: "MemoId",
                principalTable: "Memo",
                principalColumn: "MemoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemoUpload_User_CreatedUserId",
                table: "MemoUpload",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemoUpload_User_UpdatedUserId",
                table: "MemoUpload",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemoUpload_Memo_MemoId",
                table: "MemoUpload",
                column: "MemoId",
                principalTable: "Memo",
                principalColumn: "MemoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostEvaluation_User_CreatedUserId",
                table: "PostEvaluation",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostEvaluation_User_UpdatedUserId",
                table: "PostEvaluation",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostEvaluation_User_UserId",
                table: "PostEvaluation",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostEvaluation_Post_PostId",
                table: "PostEvaluation",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_User_CreatedUserId",
                table: "PostTag",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_User_UpdatedUserId",
                table: "PostTag",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_User_UserId",
                table: "PostTag",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Post_PostId",
                table: "PostTag",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUpload_User_CreatedUserId",
                table: "PostUpload",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUpload_User_UpdatedUserId",
                table: "PostUpload",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUpload_Post_PostId",
                table: "PostUpload",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Memo_User_CreatedUserId",
                table: "Memo",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Memo_User_UpdatedUserId",
                table: "Memo",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Memo_Salon_SalonId",
                table: "Memo",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "SalonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_CreatedUserId",
                table: "Post",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_UpdatedUserId",
                table: "Post",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Salon_SalonId",
                table: "Post",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "SalonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Salon_SalonId",
                table: "User",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "SalonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salon_User_CreatedUserId",
                table: "Salon");

            migrationBuilder.DropForeignKey(
                name: "FK_Salon_User_UpdatedUserId",
                table: "Salon");

            migrationBuilder.DropTable(
                name: "MemoEvaluation");

            migrationBuilder.DropTable(
                name: "MemoTag");

            migrationBuilder.DropTable(
                name: "MemoUpload");

            migrationBuilder.DropTable(
                name: "PostEvaluation");

            migrationBuilder.DropTable(
                name: "PostTag");

            migrationBuilder.DropTable(
                name: "PostUpload");

            migrationBuilder.DropTable(
                name: "UserFriend");

            migrationBuilder.DropTable(
                name: "Memo");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Salon");
        }
    }
}
