provider "aws" {
  access_key = "fake"
  secret_key = "fake"
  region = "us-east-1"
  skip_credentials_validation = true
  skip_metadata_api_check = true
  skip_requesting_account_id = true

  endpoints {
    dynamodb = "http://127.0.0.1:4566"
    sqs = "http://127.0.0.1:4566"
    sns = "http://127.0.0.1:4566"
  }
}