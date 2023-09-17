using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace microgame.Migrations
{
    /// <inheritdoc />
    public partial class fixplayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttackPoint",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentHealthPoint",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DefensePoint",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxHealthPoint",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttackPoint",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CurrentHealthPoint",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "DefensePoint",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "MaxHealthPoint",
                table: "Players");
        }
    }
}
