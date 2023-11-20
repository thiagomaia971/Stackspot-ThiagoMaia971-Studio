resource "aws_dynamodb_table_item" "user_role_data" {
    table_name = "${aws_dynamodb_table.{{solution_name}}DynamoDb.name}"
    hash_key = "${aws_dynamodb_table.{{solution_name}}DynamoDb.hash_key}"
    range_key = "${aws_dynamodb_table.{{solution_name}}DynamoDb.range_key}"
    for_each = {
        "02a01310-d8a0-48c0-a655-9755a91b4aff" = {
            Hash = "ac337365-e690-4c75-9f05-e5ea75caa1e5",
            EntityType = "UserRole",
            InheritedType = "User",
            GSI1-Id = "admin@admin.com",
            RoleId = "ac337365-e690-4c75-9f05-e5ea75caa1e5"
        },
        "c27b1bdc-9a32-4f77-a23f-62ba371c8741" = {
            Hash = "0439ac1d-c8aa-4d9b-b7b7-68d5c562eac7",
            EntityType = "UserRole",
            InheritedType = "User",
            GSI1-Id = "my-account@user.com",
            RoleId = "0439ac1d-c8aa-4d9b-b7b7-68d5c562eac7"
        }
    }
    item = <<ITEM
    {
        "Id": {"S": "${each.key}"},
        "Hash": {"S": "${each.value.Hash}"},
        "EntityType": {"S": "${each.value.EntityType}"},
        "InheritedType": {"S": "${each.value.InheritedType}"},
        "GSI1-Id": {"S": "${each.value.GSI1-Id}"},
        "RoleId": {"S": "${each.value.RoleId}"}
    }  
    ITEM

    depends_on = [
        aws_dynamodb_table.{{solution_name}}DynamoDb
    ]
}

resource "aws_dynamodb_table_item" "user_role_data_2" {
    table_name = "${aws_dynamodb_table.{{solution_name}}DynamoDb.name}"
    hash_key = "${aws_dynamodb_table.{{solution_name}}DynamoDb.hash_key}"
    range_key = "${aws_dynamodb_table.{{solution_name}}DynamoDb.range_key}"
    for_each = {
        "02a01310-d8a0-48c0-a655-9755a91b4aff" = {
            Hash = "0439ac1d-c8aa-4d9b-b7b7-68d5c562eac7",
            EntityType = "UserRole",
            GSI1-Id = "admin@admin.com",
            RoleId = "0439ac1d-c8aa-4d9b-b7b7-68d5c562eac7"
        }
    }
    item = <<ITEM
    {
        "Id": {"S": "${each.key}"},
        "Hash": {"S": "${each.value.Hash}"},
        "EntityType": {"S": "${each.value.EntityType}"},
        "GSI1-Id": {"S": "${each.value.GSI1-Id}"},
        "RoleId": {"S": "${each.value.RoleId}"}
    }  
    ITEM

    depends_on = [
        aws_dynamodb_table.{{solution_name}}DynamoDb
    ]
}