using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CP.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsultantInfo",
                columns: table => new
                {
                    ConsultantInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultantInfo", x => x.ConsultantInfoId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInfo",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultantInfoId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    MobileNo = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfo", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "DiscretionaryRules",
                columns: table => new
                {
                    DiscretionaryRuleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultantInfoId = table.Column<int>(nullable: false),
                    CustomerInfoId = table.Column<int>(nullable: false),
                    Rules = table.Column<string>(type: "xml", nullable: true),
                    CustomerBuy = table.Column<bool>(nullable: false),
                    CustomerSell = table.Column<bool>(nullable: false),
                    ConsultantBuy = table.Column<bool>(nullable: false),
                    ConsultantSell = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscretionaryRules", x => x.DiscretionaryRuleId);
                    table.ForeignKey(
                        name: "FK_DiscretionaryRules_ConsultantInfo_ConsultantInfoId",
                        column: x => x.ConsultantInfoId,
                        principalTable: "ConsultantInfo",
                        principalColumn: "ConsultantInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscretionaryRules_CustomerInfo_CustomerInfoId",
                        column: x => x.CustomerInfoId,
                        principalTable: "CustomerInfo",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscretionaryRules_ConsultantInfoId",
                table: "DiscretionaryRules",
                column: "ConsultantInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscretionaryRules_CustomerInfoId",
                table: "DiscretionaryRules",
                column: "CustomerInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscretionaryRules");

            migrationBuilder.DropTable(
                name: "ConsultantInfo");

            migrationBuilder.DropTable(
                name: "CustomerInfo");
        }
    }
}
