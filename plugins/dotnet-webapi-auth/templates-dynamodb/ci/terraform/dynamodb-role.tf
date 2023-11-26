resource "aws_dynamodb_table_item" "role_data" {
    table_name = "${aws_dynamodb_table.{{solution_name}}DynamoDb.name}"
    hash_key = "${aws_dynamodb_table.{{solution_name}}DynamoDb.hash_key}"
    range_key = "${aws_dynamodb_table.{{solution_name}}DynamoDb.range_key}"
    for_each = {
        "ac337365-e690-4c75-9f05-e5ea75caa1e5" = {
            CreatedAt = "2023-11-24T16:03:29.4171772-03:00",
            InheritedKey = "ac337365-e690-4c75-9f05-e5ea75caa1e5",
            EntityType = "{{solution_name}}.Domain.Models.Identity.Role",
            InheritedType = "{{solution_name}}.Domain.Models.Identity.Role",
            Name = "Admin"
        },
        "0439ac1d-c8aa-4d9b-b7b7-68d5c562eac7" = {
            CreatedAt = "2023-11-24T16:03:29.4171772-03:00",
            InheritedKey = "0439ac1d-c8aa-4d9b-b7b7-68d5c562eac7",
            EntityType = "{{solution_name}}.Domain.Models.Identity.Role",
            InheritedType = "{{solution_name}}.Domain.Models.Identity.Role",
            Name = "Dentista"
        }
    }
    item = <<ITEM
    {
        "Id": {"S": "${each.key}"},
        "CreatedAt": {"S": "${each.value.CreatedAt}"},
        "InheritedKey": {"S": "${each.value.InheritedKey}"},
        "EntityType": {"S": "${each.value.EntityType}"},
        "InheritedType": {"S": "${each.value.InheritedType}"},
        "Name": {"S": "${each.value.Name}"}
    }  
    ITEM

    depends_on = [
        aws_dynamodb_table.{{solution_name}}DynamoDb
    ]
}