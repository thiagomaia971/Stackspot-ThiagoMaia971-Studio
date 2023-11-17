using Amazon.DynamoDBv2.DataModel;

namespace Test.Domain.Models;

[DynamoDBTable("Test")]
public class Patient : Entity
{
}