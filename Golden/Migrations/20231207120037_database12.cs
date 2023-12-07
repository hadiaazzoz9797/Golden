using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Golden.Migrations
{
    public partial class database12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
