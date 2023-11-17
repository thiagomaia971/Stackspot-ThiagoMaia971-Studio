
namespace Test.Domain.ViewModels.Base;

public class Pagination<T>
{
    // public Dictionary<string, AttributeValue> LastEvaluatedKey { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
    public IEnumerable<T> Data { get; set; }
    public string ResultType { get; set; }
}
