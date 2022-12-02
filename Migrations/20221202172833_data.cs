using Microsoft.EntityFrameworkCore.Migrations;

namespace EfTutor.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Age", "CurrentDepartmentId", "MiddleName", "Name", "Surename" },
                values: new object[] { 1, 17, 1, null, "Vasya", "Pupkin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
