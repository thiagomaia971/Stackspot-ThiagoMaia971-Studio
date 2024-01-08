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
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Parent = table.Column<string>(type: "longtext", nullable: false),
                    Icon = table.Column<string>(type: "longtext", nullable: false),
                    Url = table.Column<string>(type: "longtext", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Visible = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DependsOn = table.Column<string>(type: "longtext", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    {{multitenant_name}}Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_{{multitenant_name}}_{{multitenant_name}}Id",
                        column: x => x.{{multitenant_name}}Id,
                        principalTable: "{{multitenant_name}}",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    RoleId = table.Column<string>(type: "varchar(36)", nullable: false),
                    RouteId = table.Column<string>(type: "varchar(36)", nullable: false),
                    IsRead = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsWrite = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permission_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permission_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    RoleId = table.Column<string>(type: "varchar(36)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_RoleId",
                table: "Permission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_RouteId",
                table: "Permission",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_{{multitenant_name}}Id",
                table: "Role",
                column: "{{multitenant_name}}Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_{{multitenant_name}}Id",
                table: "User",
                column: "{{multitenant_name}}Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

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
                new string[] { "Id", "CreatedAt", "UpdatedAt", "Name", "Parent", "Icon", "Url", "Position", "Visible", "DependsOn"  },
                new object [,]{
                    { "bf8a5e78-d655-4d83-866a-3d334b1544db", DateTimeOffset.Now.ToString("O"), null, "Home", "", "", "home", 1, true, null },
                    { "8c31e2eb-b258-4082-9540-952061f735bb", DateTimeOffset.Now.ToString("O"), null, "Counter", "Test", "Home", "counter", 1, true, null },
                    { "24c42494-9d83-4897-81b8-7fde8ee059f4", DateTimeOffset.Now.ToString("O"), null, "Weather", "Test", "Home", "weather", 2, true, null },
                    { "2ba19dde-b4aa-417a-a590-8542ecd0786c", DateTimeOffset.Now.ToString("O"), null, "{{multitenant_name}}as", "Cadastros", "FolderPlus", "{{multitenant_name}}", 1, true, null },
                    { "e325f597-374f-4f66-ac98-8adadd16fd67", DateTimeOffset.Now.ToString("O"), null, "Cargos", "Cadastros", "FolderPlus", "role", 2, true, "route" },
                    { "546c3bc1-08ba-45ba-baf1-b2dc80b30d04", DateTimeOffset.Now.ToString("O"), null, "Usuários", "Cadastros", "FolderPlus", "user", 3, true, null },
                    { "5f72ebf4-9864-4560-a3cd-e0bad76b3633", DateTimeOffset.Now.ToString("O"), null, "Permissões", "Cadastros", "FolderPlus", "permission", 4, false, null },
                    { "63006bcf-7e54-4fab-9f31-b23a1ab2cb25", DateTimeOffset.Now.ToString("O"), null, "Rotas", "", "", "route", 4, false, null },
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
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "ac337365-e690-4c75-9f05-e5ea75caa1e5", "63006bcf-7e54-4fab-9f31-b23a1ab2cb25", true, true },

                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "03eff09f-897e-48a2-bafa-f051882447fa", "bf8a5e78-d655-4d83-866a-3d334b1544db", true, true },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "03eff09f-897e-48a2-bafa-f051882447fa", "8c31e2eb-b258-4082-9540-952061f735bb", true, true },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "03eff09f-897e-48a2-bafa-f051882447fa", "24c42494-9d83-4897-81b8-7fde8ee059f4", true, true },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "03eff09f-897e-48a2-bafa-f051882447fa", "2ba19dde-b4aa-417a-a590-8542ecd0786c", false, false },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "03eff09f-897e-48a2-bafa-f051882447fa", "e325f597-374f-4f66-ac98-8adadd16fd67", true, true },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "03eff09f-897e-48a2-bafa-f051882447fa", "546c3bc1-08ba-45ba-baf1-b2dc80b30d04", true, true },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "03eff09f-897e-48a2-bafa-f051882447fa", "5f72ebf4-9864-4560-a3cd-e0bad76b3633", true, true },
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "03eff09f-897e-48a2-bafa-f051882447fa", "63006bcf-7e54-4fab-9f31-b23a1ab2cb25", true, true },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "{{multitenant_name}}");
        }
    }
}
