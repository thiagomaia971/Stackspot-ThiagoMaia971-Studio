resource "aws_dynamodb_table_item" "user_role_data" {
    table_name = "${aws_dynamodb_table.{{solution_name}}DynamoDb.name}"
    hash_key = "${aws_dynamodb_table.{{solution_name}}DynamoDb.hash_key}"
    range_key = "${aws_dynamodb_table.{{solution_name}}DynamoDb.range_key}"
    for_each = {
        "31ad3ebf-000f-4b75-bb96-11f346c38a18" = {
            CreatedAt = "2023-11-24T16:03:29.4171772-03:00",
            InheritedKey = "02a01310-d8a0-48c0-a655-9755a91b4aff",
            EntityType = "Test.Domain.Models.Identity.UserRole",
            InheritedType = "{{solution_name}}.Domain.Models.Identity.User",
            GSI-PrimaryKey = "admin@admin.com",
            RoleId = "ac337365-e690-4c75-9f05-e5ea75caa1e5"
        },
        "4277a4f7-c13d-4f68-a2ea-2204bb3508c5" = {
            CreatedAt = "2023-11-24T16:03:29.4171772-03:00",
            InheritedKey = "c27b1bdc-9a32-4f77-a23f-62ba371c8741",
            EntityType = "Test.Domain.Models.Identity.UserRole",
            InheritedType = "{{solution_name}}.Domain.Models.Identity.User",
            GSI-PrimaryKey = "nayara.do@meu.coração.com",
            RoleId = "0439ac1d-c8aa-4d9b-b7b7-68d5c562eac7"
        }
    }
    item = <<ITEM
    {
        "Id": {"S": "${each.key}"},
        "CreatedAt": {"S": "${each.value.CreatedAt}"},
        "InheritedKey": {"S": "${each.value.InheritedKey}"},
        "EntityType": {"S": "${each.value.EntityType}"},
        "InheritedType": {"S": "${each.value.InheritedType}"},
        "GSI-PrimaryKey": {"S": "${each.value.GSI-PrimaryKey}"},
        "RoleId": {"S": "${each.value.RoleId}"}
    }  
    ITEM

    depends_on = [
        aws_dynamodb_table.{{solution_name}}DynamoDb
    ]
}
