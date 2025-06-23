using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create_FullName_to_users_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "full_name",
                table: "users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "full_name",
                table: "users");
        }
    }
}
