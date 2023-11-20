resource "aws_dynamodb_table" "{{solution_name}}DynamoDb" {
    name = "{{solution_name}}"
    billing_mode = "PROVISIONED"
    read_capacity = 5
    write_capacity = 5
    hash_key = "Id"
    range_key = "Hash"

    attribute {
        name = "Id"
        type = "S"
    }

    attribute {
        name = "Hash"
        type = "S"
    }

    attribute {
        name = "EntityType"
        type = "S"
    }

    attribute {
        name = "InheritedType"
        type = "S"
    }

    attribute {
        name = "UserId"
        type = "S"
    }

    attribute {
        name = "GSI1-Id"
        type = "S"
    }

    attribute {
        name = "GSI1-Hash"
        type = "S"
    }

    global_secondary_index {
        hash_key = "Hash"
        name = "GSI-Hash"
        projection_type = "ALL"
        read_capacity = 100
        write_capacity = 100
    }

    global_secondary_index {
        hash_key = "EntityType" 
        name = "GSI-EntityType"
        projection_type = "ALL"
        read_capacity = 100
        write_capacity = 100
    }

    global_secondary_index {
        hash_key = "InheritedType" 
        name = "GSI-InheritedType"
        projection_type = "ALL"
        read_capacity = 100
        write_capacity = 100
    }

    global_secondary_index {
        hash_key = "UserId"
        name = "GSI-UserId"
        projection_type = "ALL"
        read_capacity = 100
        write_capacity = 100
    }

    global_secondary_index {
        hash_key = "GSI1-Id"
        name = "GSI1-Id"
        projection_type = "ALL"
        read_capacity = 100
        write_capacity = 100
    }

    global_secondary_index {
        hash_key = "GSI1-Hash"
        name = "GSI1-Hash"
        projection_type = "ALL"
        read_capacity = 100
        write_capacity = 100
    }
}