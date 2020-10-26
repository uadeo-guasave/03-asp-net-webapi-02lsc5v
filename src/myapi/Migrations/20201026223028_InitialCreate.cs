using Microsoft.EntityFrameworkCore.Migrations;

namespace myapi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //     name: "users",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(nullable: false)
            //             .Annotation("Sqlite:Autoincrement", true),
            //         name = table.Column<string>(maxLength: 20, nullable: false),
            //         password = table.Column<string>(maxLength: 16, nullable: false),
            //         email = table.Column<string>(maxLength: 200, nullable: false),
            //         firstname = table.Column<string>(maxLength: 50, nullable: false),
            //         lastname = table.Column<string>(maxLength: 50, nullable: false),
            //         gender = table.Column<string>(maxLength: 6, nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_users", x => x.id);
            //     });

            // migrationBuilder.CreateIndex(
            //     name: "IX_users_email",
            //     table: "users",
            //     column: "email",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "IX_users_name",
            //     table: "users",
            //     column: "name",
            //     unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
