using Microsoft.EntityFrameworkCore.Migrations;

namespace CP.Migrations
{
    public partial class CustomerInfoId_rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscretionaryRules_CustomerInfo_CustomerInfoId",
                table: "DiscretionaryRules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerInfo",
                table: "CustomerInfo");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerInfo");

            migrationBuilder.AddColumn<int>(
                name: "CustomerInfoId",
                table: "CustomerInfo",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerInfo",
                table: "CustomerInfo",
                column: "CustomerInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscretionaryRules_CustomerInfo_CustomerInfoId",
                table: "DiscretionaryRules",
                column: "CustomerInfoId",
                principalTable: "CustomerInfo",
                principalColumn: "CustomerInfoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscretionaryRules_CustomerInfo_CustomerInfoId",
                table: "DiscretionaryRules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerInfo",
                table: "CustomerInfo");

            migrationBuilder.DropColumn(
                name: "CustomerInfoId",
                table: "CustomerInfo");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "CustomerInfo",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerInfo",
                table: "CustomerInfo",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscretionaryRules_CustomerInfo_CustomerInfoId",
                table: "DiscretionaryRules",
                column: "CustomerInfoId",
                principalTable: "CustomerInfo",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
