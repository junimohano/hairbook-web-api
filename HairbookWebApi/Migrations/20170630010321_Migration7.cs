using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairbookWebApi.Migrations
{
    public partial class Migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_HairType_HairTypeId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_HairTypeId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "HairTypeId",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "HairMemo",
                table: "Post",
                newName: "HairTypeMemo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HairTypeMemo",
                table: "Post",
                newName: "HairMemo");

            migrationBuilder.AddColumn<int>(
                name: "HairTypeId",
                table: "Post",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_HairTypeId",
                table: "Post",
                column: "HairTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_HairType_HairTypeId",
                table: "Post",
                column: "HairTypeId",
                principalTable: "HairType",
                principalColumn: "HairTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
