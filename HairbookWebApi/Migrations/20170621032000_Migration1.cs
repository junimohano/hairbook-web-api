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
                name: "HairMenu",
                columns: table => new
                {
                    HairMenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairMenu", x => x.HairMenuId);
                });

            migrationBuilder.CreateTable(
                name: "HairType",
                columns: table => new
                {
                    HairTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairType", x => x.HairTypeId);
                });

            migrationBuilder.CreateTable(
                name: "HairSubMenu",
                columns: table => new
                {
                    HairSubMenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HairMenuId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairSubMenu", x => x.HairSubMenuId);
                    table.ForeignKey(
                        name: "FK_HairSubMenu_HairMenu_HairMenuId",
                        column: x => x.HairMenuId,
                        principalTable: "HairMenu",
                        principalColumn: "HairMenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessType = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    HairMemo = table.Column<string>(nullable: true),
                    HairTypeId = table.Column<int>(nullable: true),
                    Memo = table.Column<string>(nullable: true),
                    SalonId = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_HairType_HairTypeId",
                        column: x => x.HairTypeId,
                        principalTable: "HairType",
                        principalColumn: "HairTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostHairMenu",
                columns: table => new
                {
                    PostHairMenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    Drawing = table.Column<byte[]>(nullable: true),
                    HairMenuId = table.Column<int>(nullable: false),
                    HairSubMenuId = table.Column<int>(nullable: true),
                    Memo = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostHairMenu", x => x.PostHairMenuId);
                    table.UniqueConstraint("AK_PostHairMenu_PostId_PostHairMenuId", x => new { x.PostId, x.PostHairMenuId });
                    table.ForeignKey(
                        name: "FK_PostHairMenu_HairMenu_HairMenuId",
                        column: x => x.HairMenuId,
                        principalTable: "HairMenu",
                        principalColumn: "HairMenuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostHairMenu_HairSubMenu_HairSubMenuId",
                        column: x => x.HairSubMenuId,
                        principalTable: "HairSubMenu",
                        principalColumn: "HairSubMenuId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostHairMenu_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostHairType",
                columns: table => new
                {
                    PostHairTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    HairTypeId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostHairType", x => x.PostHairTypeId);
                    table.UniqueConstraint("AK_PostHairType_PostId_PostHairTypeId", x => new { x.PostId, x.PostHairTypeId });
                    table.ForeignKey(
                        name: "FK_PostHairType_HairType_HairTypeId",
                        column: x => x.HairTypeId,
                        principalTable: "HairType",
                        principalColumn: "HairTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostHairType_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostComment",
                columns: table => new
                {
                    PostCommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComment", x => x.PostCommentId);
                    table.ForeignKey(
                        name: "FK_PostComment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostEvaluation",
                columns: table => new
                {
                    PostEvaluationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
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
                    table.UniqueConstraint("AK_PostEvaluation_PostId_UserId", x => new { x.PostId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PostEvaluation_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostUpload",
                columns: table => new
                {
                    PostUploadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    Memo = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true),
                    UploadCategoryType = table.Column<int>(nullable: false),
                    UploadFileType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUpload", x => x.PostUploadId);
                    table.ForeignKey(
                        name: "FK_PostUpload_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
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
                    UpdatedUserId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCommentTag", x => x.PostCommentTagId);
                    table.ForeignKey(
                        name: "FK_PostCommentTag_PostComment_PostCommentId",
                        column: x => x.PostCommentId,
                        principalTable: "PostComment",
                        principalColumn: "PostCommentId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_Tag_PostComment_PostCommentId",
                        column: x => x.PostCommentId,
                        principalTable: "PostComment",
                        principalColumn: "PostCommentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    SalonId = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true),
                    UserKey = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
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
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDay = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_User_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_User_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salon",
                columns: table => new
                {
                    SalonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
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
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    FriendId = table.Column<int>(nullable: false),
                    IsFriend = table.Column<bool>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CreatedUserId",
                table: "Customer",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UpdatedUserId",
                table: "Customer",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId",
                table: "Customer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HairSubMenu_HairMenuId",
                table: "HairSubMenu",
                column: "HairMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CreatedUserId",
                table: "Post",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CustomerId",
                table: "Post",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_HairTypeId",
                table: "Post",
                column: "HairTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_SalonId",
                table: "Post",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UpdatedUserId",
                table: "Post",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_CreatedUserId",
                table: "PostComment",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_PostId",
                table: "PostComment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_UpdatedUserId",
                table: "PostComment",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_UserId",
                table: "PostComment",
                column: "UserId");

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
                name: "IX_PostCommentTag_UserId",
                table: "PostCommentTag",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostEvaluation_CreatedUserId",
                table: "PostEvaluation",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostEvaluation_UpdatedUserId",
                table: "PostEvaluation",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostEvaluation_UserId",
                table: "PostEvaluation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostHairMenu_CreatedUserId",
                table: "PostHairMenu",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostHairMenu_HairMenuId",
                table: "PostHairMenu",
                column: "HairMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_PostHairMenu_HairSubMenuId",
                table: "PostHairMenu",
                column: "HairSubMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_PostHairMenu_UpdatedUserId",
                table: "PostHairMenu",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostHairType_CreatedUserId",
                table: "PostHairType",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostHairType_HairTypeId",
                table: "PostHairType",
                column: "HairTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PostHairType_UpdatedUserId",
                table: "PostHairType",
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
                name: "FK_Post_Customer_CustomerId",
                table: "Post",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Salon_SalonId",
                table: "Post",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "SalonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostHairMenu_User_CreatedUserId",
                table: "PostHairMenu",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostHairMenu_User_UpdatedUserId",
                table: "PostHairMenu",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostHairType_User_CreatedUserId",
                table: "PostHairType",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostHairType_User_UpdatedUserId",
                table: "PostHairType",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComment_User_CreatedUserId",
                table: "PostComment",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComment_User_UpdatedUserId",
                table: "PostComment",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComment_User_UserId",
                table: "PostComment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

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
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_PostCommentTag_User_CreatedUserId",
                table: "PostCommentTag",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostCommentTag_User_UpdatedUserId",
                table: "PostCommentTag",
                column: "UpdatedUserId",
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
                name: "FK_PostCommentTag_Tag_TagId",
                table: "PostCommentTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_User_CreatedUserId",
                table: "Tag",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_User_UpdatedUserId",
                table: "Tag",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

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
                name: "PostCommentTag");

            migrationBuilder.DropTable(
                name: "PostEvaluation");

            migrationBuilder.DropTable(
                name: "PostHairMenu");

            migrationBuilder.DropTable(
                name: "PostHairType");

            migrationBuilder.DropTable(
                name: "PostUpload");

            migrationBuilder.DropTable(
                name: "UserFriend");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "HairSubMenu");

            migrationBuilder.DropTable(
                name: "PostComment");

            migrationBuilder.DropTable(
                name: "HairMenu");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "HairType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Salon");
        }
    }
}
