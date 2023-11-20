resource "aws_dynamodb_table_item" "user_data_1" {
    table_name = "${aws_dynamodb_table.{{solution_name}}DynamoDb.name}"
    hash_key = "${aws_dynamodb_table.{{solution_name}}DynamoDb.hash_key}"
    range_key = "${aws_dynamodb_table.{{solution_name}}DynamoDb.range_key}"
    for_each = {
        "02a01310-d8a0-48c0-a655-9755a91b4aff" = {
            Hash = "02a01310-d8a0-48c0-a655-9755a91b4aff",
            EntityType = "User",
            InheritedType = "User",
            GSI1-Id = "admin@admin.com",
            GSI1-Hash = "admin",
            Nome = "Admin",
            PasswordHash = "AQAAAAEAACcQAAAAEEHP6dksHxraYptLNNadEse/60t177wcgZs6ST66LR9xBzx883uvUVu1DeDyaOExkA==",
            Roles = "['ac337365-e690-4c75-9f05-e5ea75caa1e5']"
        },
        "c27b1bdc-9a32-4f77-a23f-62ba371c8741" = {
            Hash = "c27b1bdc-9a32-4f77-a23f-62ba371c8741",
            EntityType = "User",
            InheritedType = "User",
            GSI1-Id = "my-account@user.com",
            GSI1-Hash = "user",
            Nome = "Common User",
            PasswordHash = "AQAAAAEAACcQAAAAEEHP6dksHxraYptLNNadEse/60t177wcgZs6ST66LR9xBzx883uvUVu1DeDyaOExkA==",
            Roles = "['0439ac1d-c8aa-4d9b-b7b7-68d5c562eac7']"
        }
    }
    item = <<ITEM
    {
        "Id": {"S": "${each.key}"},
        "Hash": {"S": "${each.value.Hash}"},
        "EntityType": {"S": "${each.value.EntityType}"},
        "InheritedType": {"S": "${each.value.InheritedType}"},
        "GSI1-Id": {"S": "${each.value.GSI1-Id}"},
        "GSI1-Hash": {"S": "${each.value.GSI1-Hash}"},
        "Nome": {"S": "${each.value.Nome}"},
        "PasswordHash": {"S": "${each.value.PasswordHash}"},
        "Roles": {"S": "${each.value.Roles}"}
    }  
    ITEM

    depends_on = [
        aws_dynamodb_table.{{solution_name}}DynamoDb
    ]
}