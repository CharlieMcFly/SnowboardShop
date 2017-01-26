using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SnowboardShop.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Snowboard",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    camber = table.Column<string>(nullable: true),
                    flex = table.Column<string>(nullable: true),
                    height = table.Column<int>(nullable: false),
                    marque = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    price = table.Column<decimal>(nullable: false),
                    shape = table.Column<string>(nullable: true),
                    urlPhoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snowboard", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Snowboard");
        }
    }
}
