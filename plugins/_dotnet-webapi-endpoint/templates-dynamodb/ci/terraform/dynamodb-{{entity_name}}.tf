resource "aws_dynamodb_table_item" "{{entity_name}}_data" {
    table_name = "${aws_dynamodb_table.{{solution_name}}DynamoDb.name}"
    hash_key = "${aws_dynamodb_table.{{solution_name}}DynamoDb.hash_key}"
    range_key = "${aws_dynamodb_table.{{solution_name}}DynamoDb.range_key}"
    for_each = {
        "5702c161-1589-49a0-92b8-75059304bef7" = {
            Hash = "5702c161-1589-49a0-92b8-75059304bef7",
            EntityType = "{{entity_name}}",
            InheritedType = "{{entity_name}}",
            GSI-PrimaryKey = "Any Name"
        }
    }
    item = <<ITEM
    {
        "Id": {"S": "${each.key}"},
        "Hash": {"S": "${each.value.ForeingKey}"},
        "EntityType": {"S": "${each.value.EntityType}"},
        "InheritedType": {"S": "${each.value.InheritedType}"},
        "GSI-PrimaryKey": {"S": "${each.value.GSI-PrimaryKey}"}
    }  
    ITEM

    depends_on = [
        aws_dynamodb_table.{{solution_name}}DynamoDb
    ]
}