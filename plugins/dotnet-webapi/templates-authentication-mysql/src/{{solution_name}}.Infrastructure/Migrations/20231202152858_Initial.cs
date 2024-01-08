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
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    Route = table.Column<string>(type: "longtext", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
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
                name: "RolePermission",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    RoleId = table.Column<string>(type: "varchar(36)", nullable: false),
                    PermissionId = table.Column<string>(type: "varchar(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
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
                name: "IX_RolePermission_PermissionId",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId",
                table: "RolePermission",
                column: "RoleId");

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
                    { "82058314-b3a4-4052-b9fc-ae5d0ac5790b", DateTimeOffset.Now.ToString("O"), null, "ADMIN" },
                    { "b18ac808-33ed-4c4f-81f9-bbc863f6f5d3", DateTimeOffset.Now.ToString("O"), null, "Tidy" },
                });

            migrationBuilder.InsertData(
                "Role",
                new string[] { "Id", "CreatedAt", "UpdatedAt", "{{multitenant_name}}Id", "Name" },
                new object [,]{
                    { "ac337365-e690-4c75-9f05-e5ea75caa1e5", DateTimeOffset.Now.ToString("O"), null, "82058314-b3a4-4052-b9fc-ae5d0ac5790b", "ADMIN" },
                    { "03eff09f-897e-48a2-bafa-f051882447fa", DateTimeOffset.Now.ToString("O"), null, "b18ac808-33ed-4c4f-81f9-bbc863f6f5d3", "Administrador" },
                });

            migrationBuilder.InsertData(
                "User",
                new string[] { "Id", "CreatedAt", "UpdatedAt", "{{multitenant_name}}Id", "Name", "Email", "EmailConfirmed", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled"  },
                new object [,]{
                    { "02a01310-d8a0-48c0-a655-9755a91b4aff", DateTimeOffset.Now.ToString("O"), null, "82058314-b3a4-4052-b9fc-ae5d0ac5790b", "Admin", "admin@admin.com", true, "AQAAAAEAACcQAAAAEEHP6dksHxraYptLNNadEse/60t177wcgZs6ST66LR9xBzx883uvUVu1DeDyaOExkA==", "8888", true, false },
                    { "e4377840-4f9c-4abd-93ad-3da3491a287c", DateTimeOffset.Now.ToString("O"), null, "b18ac808-33ed-4c4f-81f9-bbc863f6f5d3", "CEO Tidy", "tidy-admin@admin.com", true, "AQAAAAEAACcQAAAAEEHP6dksHxraYptLNNadEse/60t177wcgZs6ST66LR9xBzx883uvUVu1DeDyaOExkA==", "8888", true, false },
                });

            migrationBuilder.InsertData(
                "UserRole",
                new string[] { "Id", "CreatedAt", "UpdatedAt", "RoleId", "UserId"  },
                new object [,]{
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "ac337365-e690-4c75-9f05-e5ea75caa1e5", "02a01310-d8a0-48c0-a655-9755a91b4aff" },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "03eff09f-897e-48a2-bafa-f051882447fa", "e4377840-4f9c-4abd-93ad-3da3491a287c" },
                });

            migrationBuilder.InsertData(
                "Route",
                new string[] { "Id", "CreatedAt", "UpdatedAt", "Name", "Parent", "Icon", "Url", "Position"  },
                new object [,]{
                    { "bf8a5e78-d655-4d83-866a-3d334b1544db", DateTimeOffset.Now.ToString("O"), null, "Home", "", "", "home", 1 },
                    { "8c31e2eb-b258-4082-9540-952061f735bb", DateTimeOffset.Now.ToString("O"), null, "Counter", "Test", "Home", "counter", 1 },
                    { "24c42494-9d83-4897-81b8-7fde8ee059f4", DateTimeOffset.Now.ToString("O"), null, "Weather", "Test", "Home", "weather", 2 },
                    { "2ba19dde-b4aa-417a-a590-8542ecd0786c", DateTimeOffset.Now.ToString("O"), null, "Empresas", "Cadastro", "FolderPlus", "companies", 1 },
                    { "e325f597-374f-4f66-ac98-8adadd16fd67", DateTimeOffset.Now.ToString("O"), null, "Cargos", "Cadastro", "FolderPlus", "roles", 2 },
                    { "546c3bc1-08ba-45ba-baf1-b2dc80b30d04", DateTimeOffset.Now.ToString("O"), null, "Usuários", "Cadastro", "FolderPlus", "users", 3 },
                    { "5f72ebf4-9864-4560-a3cd-e0bad76b3633", DateTimeOffset.Now.ToString("O"), null, "Permissões", "Cadastro", "FolderPlus", "permissions", 4 },
                });

            migrationBuilder.InsertData(
                "Permission",
                new string[] { "Id", "CreatedAt", "UpdatedAt", "RoleId", "RouteId", "IsRead", "IsWrite"  },
                new object [,]{
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "ac337365-e690-4c75-9f05-e5ea75caa1e5", "bf8a5e78-d655-4d83-866a-3d334b1544db", true, true },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "ac337365-e690-4c75-9f05-e5ea75caa1e5", "8c31e2eb-b258-4082-9540-952061f735bb", true, true },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "ac337365-e690-4c75-9f05-e5ea75caa1e5", "24c42494-9d83-4897-81b8-7fde8ee059f4", true, true },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "ac337365-e690-4c75-9f05-e5ea75caa1e5", "2ba19dde-b4aa-417a-a590-8542ecd0786c", true, true },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "ac337365-e690-4c75-9f05-e5ea75caa1e5", "e325f597-374f-4f66-ac98-8adadd16fd67", true, true },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "ac337365-e690-4c75-9f05-e5ea75caa1e5", "546c3bc1-08ba-45ba-baf1-b2dc80b30d04", true, true },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "ac337365-e690-4c75-9f05-e5ea75caa1e5", "5f72ebf4-9864-4560-a3cd-e0bad76b3633", true, true },

                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "03eff09f-897e-48a2-bafa-f051882447fa", "bf8a5e78-d655-4d83-866a-3d334b1544db", true, true },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "03eff09f-897e-48a2-bafa-f051882447fa", "8c31e2eb-b258-4082-9540-952061f735bb", true, true },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "03eff09f-897e-48a2-bafa-f051882447fa", "24c42494-9d83-4897-81b8-7fde8ee059f4", true, true },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "03eff09f-897e-48a2-bafa-f051882447fa", "2ba19dde-b4aa-417a-a590-8542ecd0786c", false, false },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "03eff09f-897e-48a2-bafa-f051882447fa", "e325f597-374f-4f66-ac98-8adadd16fd67", true, true },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "03eff09f-897e-48a2-bafa-f051882447fa", "546c3bc1-08ba-45ba-baf1-b2dc80b30d04", true, true },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "03eff09f-897e-48a2-bafa-f051882447fa", "5f72ebf4-9864-4560-a3cd-e0bad76b3633", true, true },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "{{multitenant_name}}");
        }
    }
}
