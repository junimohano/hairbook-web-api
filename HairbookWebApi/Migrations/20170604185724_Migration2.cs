using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairbookWebApi.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memo_Salon_SalonId",
                table: "Memo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserFriend",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 925, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "User",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 925, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tag",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 925, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Salon",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 925, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PostUpload",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 925, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PostTag",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 925, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PostEvaluation",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 924, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Post",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 924, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MemoUpload",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 924, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MemoTag",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 924, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MemoEvaluation",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 773, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 924, DateTimeKind.Local));

            migrationBuilder.AlterColumn<int>(
                name: "SalonId",
                table: "Memo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Memo",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 764, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 916, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_Memo_Salon_SalonId",
                table: "Memo",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "SalonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memo_Salon_SalonId",
                table: "Memo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserFriend",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 925, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "User",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 925, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tag",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 925, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Salon",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 925, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PostUpload",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 925, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PostTag",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 925, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PostEvaluation",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 924, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Post",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 924, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MemoUpload",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 924, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MemoTag",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 924, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 774, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MemoEvaluation",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 924, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 773, DateTimeKind.Local));

            migrationBuilder.AlterColumn<int>(
                name: "SalonId",
                table: "Memo",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Memo",
                nullable: true,
                defaultValue: new DateTime(2017, 6, 1, 20, 17, 10, 916, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2017, 6, 4, 14, 57, 23, 764, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_Memo_Salon_SalonId",
                table: "Memo",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "SalonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
