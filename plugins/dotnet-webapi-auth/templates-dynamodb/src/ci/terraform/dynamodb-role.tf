resource "aws_dynamodb_table_item" "role_data" {
    table_name = "${aws_dynamodb_table.{{solution_name}}DynamoDb.name}"
    hash_key = "${aws_dynamodb_table.{{solution_name}}DynamoDb.hash_key}"
    range_key = "${aws_dynamodb_table.{{solution_name}}DynamoDb.range_key}"
    for_each = {
        "ac337365-e690-4c75-9f05-e5ea75caa1e5" = {
            Hash = "ac337365-e690-4c75-9f05-e5ea75caa1e5",
            EntityType = "Role",
            InheritedType = "Role",
            Nome = "Admin"
        },
        "0439ac1d-c8aa-4d9b-b7b7-68d5c562eac7" = {
            Hash = "0439ac1d-c8aa-4d9b-b7b7-68d5c562eac7",
            EntityType = "Role",
            InheritedType = "Role",
            Nome = "CommonUser"
        }
    }
    item = <<ITEM
    {
        "Id": {"S": "${each.key}"},
        "Hash": {"S": "${each.value.Hash}"},
        "EntityType": {"S": "${each.value.EntityType}"},
        "InheritedType": {"S": "${each.value.InheritedType}"},
        "Nome": {"S": "${each.value.Nome}"}
    }  
    ITEM

    depends_on = [
        aws_dynamodb_table.{{solution_name}}DynamoDb
    ]
}