using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairbookWebApi.Migrations
{
    public partial class Migration27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadFileRotation",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UploadFileRotation",
                table: "PostUpload");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UploadFileRotation",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UploadFileRotation",
                table: "PostUpload",
                nullable: false,
                defaultValue: 0);
        }
    }
}
