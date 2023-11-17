using Newtonsoft.Json;

namespace {{solution_name}}.Domain.Models;

public class Entity {
    [JsonProperty("Id")]
    public string Id { get; private set; }

    public Entity()
    {
        Id = Guid.NewGuid().ToString();
    }
}