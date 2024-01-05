{% macro uuid() -%}
{%- set ns = namespace(uuid = 'xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx') %}
{%- set ns.new_uuid = '' %}
{%- for x in ns.uuid %}
{%- set ns.new_uuid = [ns.new_uuid,(x | replace('x', [0,1,2,3,4,5,6,7,8,9,'a','b','c','d','e','f'] | random ))] | join %}
{%- endfor %}
{{ns.new_uuid}}
{%- endmacro %}
{%set route_id = uuid()%}

            migrationBuilder.InsertData(
                "Route",
                new string[] { "Id", "CreatedAt", "UpdatedAt", "Name", "Parent", "Icon", "Url", "Position", "Visible", "DependsOn"  },
                new object [,]{
                    { "{{route_id}}", DateTimeOffset.Now.ToString("O"), null, "{{entity_name}}", "Cadastros", "FolderPlus", "{{entity_name|lower}}", 1, true, null }
                });
                
            migrationBuilder.InsertData(
                "Permission",
                new string[] { "Id", "CreatedAt", "UpdatedAt", "RoleId", "RouteId", "IsRead", "IsWrite"  },
                new object [,]{
                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "ac337365-e690-4c75-9f05-e5ea75caa1e5", "{{route_id}}", true, true },

                    { Guid.NewGuid().ToString(), DateTimeOffset.Now.ToString("O"), null, "03eff09f-897e-48a2-bafa-f051882447fa", "{{route_id}}", true, true },
                });

