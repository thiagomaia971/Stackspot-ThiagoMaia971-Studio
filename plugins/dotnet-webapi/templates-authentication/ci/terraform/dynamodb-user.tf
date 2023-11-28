resource "aws_dynamodb_table_item" "user_data_1" {
    table_name = "${aws_dynamodb_table.{{solution_name}}DynamoDb.name}"
    hash_key = "${aws_dynamodb_table.{{solution_name}}DynamoDb.hash_key}"
    range_key = "${aws_dynamodb_table.{{solution_name}}DynamoDb.range_key}"
    for_each = {
        "02a01310-d8a0-48c0-a655-9755a91b4aff" = {
            CreatedAt = "2023-11-24T16:03:29.4171772-03:00",
            InheritedKey = "02a01310-d8a0-48c0-a655-9755a91b4aff",
            EntityType = "{{solution_name}}.Domain.Models.Identity.User",
            InheritedType = "{{solution_name}}.Domain.Models.Identity.User",
            GSI-PrimaryKey = "admin@admin.com",
            GSI-PrimaryInheritedKey = "admin",
            Name = "Admin",
            PasswordHash = "AQAAAAEAACcQAAAAEEHP6dksHxraYptLNNadEse/60t177wcgZs6ST66LR9xBzx883uvUVu1DeDyaOExkA=="
        },
        "c27b1bdc-9a32-4f77-a23f-62ba371c8741" = {
            CreatedAt = "2023-11-24T16:03:29.4171772-03:00",
            InheritedKey = "c27b1bdc-9a32-4f77-a23f-62ba371c8741",
            EntityType = "{{solution_name}}.Domain.Models.Identity.User",
            InheritedType = "{{solution_name}}.Domain.Models.Identity.User",
            GSI-PrimaryKey = "another.user@email.com",
            GSI-PrimaryInheritedKey = "nayara",
            Name = "Another User",
            PasswordHash = "AQAAAAEAACcQAAAAEEHP6dksHxraYptLNNadEse/60t177wcgZs6ST66LR9xBzx883uvUVu1DeDyaOExkA=="
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
        "GSI-PrimaryInheritedKey": {"S": "${each.value.GSI-PrimaryInheritedKey}"},
        "Name": {"S": "${each.value.Name}"},
        "PasswordHash": {"S": "${each.value.PasswordHash}"}
    }  
    ITEM

    depends_on = [
        aws_dynamodb_table.{{solution_name}}DynamoDb
    ]
}