using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FullTextSearch.DBCreator.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    AppId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppName = table.Column<string>(nullable: true),
                    AppCategory = table.Column<string>(nullable: true),
                    AppRating = table.Column<double>(nullable: true),
                    AppReviews = table.Column<int>(nullable: true),
                    AppSizeInKb = table.Column<double>(nullable: true),
                    AppInstalls = table.Column<string>(nullable: true),
                    AppType = table.Column<int>(nullable: false),
                    AppPrice = table.Column<double>(nullable: true),
                    AppContentRating = table.Column<string>(nullable: true),
                    AppGenres = table.Column<string>(nullable: true),
                    AppLastUpdate = table.Column<DateTime>(nullable: false),
                    AppVersion = table.Column<string>(nullable: true),
                    AppAndroidRequirement = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.AppId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");
        }
    }
}
