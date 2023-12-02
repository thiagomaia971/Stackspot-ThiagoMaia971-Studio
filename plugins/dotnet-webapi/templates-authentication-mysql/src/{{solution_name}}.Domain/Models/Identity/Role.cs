using Newtonsoft.Json;
using CruderSimple.Core.ViewModels;
using CruderSimple.MySql.Entities;

namespace {{solution_name}}.Domain.Models.Identity;

public class Role : Entity
{
    [JsonProperty("Name")]
    public string Name { get; set; }

    public override Entity FromInput(InputDto input)
    {
        throw new NotImplementedException();
    }

    public override OutputDto ToOutput()
    {
        throw new NotImplementedException();
    }
}