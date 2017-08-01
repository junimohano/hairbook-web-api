using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairbookWebApi.Migrations
{
    public partial class Migration25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsMemo",
                table: "PostHairMenu",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHairTypeMemo",
                table: "Post",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMemo",
                table: "Post",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMemo",
                table: "PostHairMenu");

            migrationBuilder.DropColumn(
                name: "IsHairTypeMemo",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "IsMemo",
                table: "Post");
        }
    }
}
