using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NETCoreExperimentalWebApp.Migrations
{
    public partial class AddUserID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "Book");
        }
    }
}
