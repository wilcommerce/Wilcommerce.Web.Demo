using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wilcommerce.Core.Data.EFCore.Migrations.Migrations
{
    public partial class EventsInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wilcommerce_Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: true),
                    AggregateId = table.Column<Guid>(nullable: false),
                    AggregateType = table.Column<string>(nullable: true),
                    EventType = table.Column<string>(nullable: true),
                    EventBody = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wilcommerce_Events", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wilcommerce_Events");
        }
    }
}
