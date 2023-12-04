using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace {{solution_name}}.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "{{multitenant_name}}",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_{{multitenant_name}}", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    {{multitenant_name}}Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_{{multitenant_name}}_{{multitenant_name}}Id",
                        column: x => x.{{multitenant_name}}Id,
                        principalTable: "{{multitenant_name}}",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    RoleId = table.Column<string>(type: "longtext", nullable: false),
                    UserId = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_User_{{multitenant_name}}Id",
                table: "User",
                column: "{{multitenant_name}}Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
            

            migrationBuilder.InsertData(
                "{{multitenant_name}}",
                new string[] { "Id", "CreatedAt", "UpdatedAt", "Name" },
                new object [,]{
                    { "82058314-b3a4-4052-b9fc-ae5d0ac5790b", DateTimeOffset.Now.ToString("O"), null, "ADMIN" }
                });

            migrationBuilder.InsertData(
                "Role",
                new string[] { "Id", "CreatedAt", "UpdatedAt", "Name" },
                new object [,]{
                    { "ac337365-e690-4c75-9f05-e5ea75caa1e5", DateTimeOffset.Now.ToString("O"), null, "ADMIN" }
                });

            migrationBuilder.InsertData(
                "User",
                new string[] { "Id", "CreatedAt", "UpdatedAt", "{{multitenant_name}}Id", "Name", "Email", "EmailConfirmed", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled"  },
                new object [,]{
                    { "02a01310-d8a0-48c0-a655-9755a91b4aff", DateTimeOffset.Now.ToString("O"), null, "82058314-b3a4-4052-b9fc-ae5d0ac5790b", "Admin", "admin@admin.com", true, "AQAAAAEAACcQAAAAEEHP6dksHxraYptLNNadEse/60t177wcgZs6ST66LR9xBzx883uvUVu1DeDyaOExkA==", "8888", true, false }
                });

            migrationBuilder.InsertData(
                "UserRole",
                new string[] { "Id", "CreatedAt", "UpdatedAt", "RoleId", "UserId"  },
                new object [,]{
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "ac337365-e690-4c75-9f05-e5ea75caa1e5", "02a01310-d8a0-48c0-a655-9755a91b4aff" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "{{multitenant_name}}");
        }
    }
}
