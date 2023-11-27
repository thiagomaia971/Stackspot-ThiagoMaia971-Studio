{% macro uuid() -%}
{%- set ns = namespace(uuid = 'xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx') %}
{%- set ns.new_uuid = '' %}
{%- for x in ns.uuid %}
{%- set ns.new_uuid = [ns.new_uuid,(x | replace('x', [0,1,2,3,4,5,6,7,8,9,'a','b','c','d','e','f'] | random ))] | join %}
{%- endfor %}
{{ns.new_uuid}}
{%- endmacro %}
{%set entityId = uuid()%}
resource "aws_dynamodb_table_item" "{{entity_name}}_data" {
    table_name = "${aws_dynamodb_table.{{solution_name}}DynamoDb.name}"
    hash_key = "${aws_dynamodb_table.{{solution_name}}DynamoDb.hash_key}"
    range_key = "${aws_dynamodb_table.{{solution_name}}DynamoDb.range_key}"
    for_each = {
        "{{entityId}}" = {
            CreatedAt = "2023-11-24T16:03:29.4171772-03:00",
            InheritedKey = "{{entityId}}",
            EntityType = "{{solution_name}}.Domain.Models.{{entity_name}}",
            InheritedType = "{{solution_name}}.Domain.Models.{{entity_name}}",
            GSI-PrimaryKey = "Any Name"
        }
    }
    item = <<ITEM
    {
        "Id": {"S": "${each.key}"},
        "CreatedAt": {"S": "${each.value.CreatedAt}"},
        "InheritedKey": {"S": "${each.value.InheritedKey}"},
        "EntityType": {"S": "${each.value.EntityType}"},
        "InheritedType": {"S": "${each.value.InheritedType}"},
        "GSI-PrimaryKey": {"S": "${each.value.GSI-PrimaryKey}"}
    }  
    ITEM

    depends_on = [
        aws_dynamodb_table.{{solution_name}}DynamoDb
    ]
}