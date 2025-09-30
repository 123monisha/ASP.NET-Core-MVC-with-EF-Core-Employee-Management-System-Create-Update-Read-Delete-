using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Departments Values('Admin')");
            migrationBuilder.Sql("Insert into Departments Values('Account')");
            migrationBuilder.Sql("Insert into Departments Values('Sales')");
            migrationBuilder.Sql("Insert into Departments Values('Finanace')");
            migrationBuilder.Sql("Insert into Departments Values('Marketing')");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
