using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntregaFinalAcademia.Migrations
{
    public partial class initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "job_id",
                keyValue: 1,
                column: "job_date",
                value: new DateTime(2023, 9, 16, 18, 53, 33, 159, DateTimeKind.Local).AddTicks(7619));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "job_id",
                keyValue: 1,
                column: "job_date",
                value: new DateTime(2023, 9, 16, 18, 50, 43, 591, DateTimeKind.Local).AddTicks(5381));
        }
    }
}
