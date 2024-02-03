using CruderSimple.Core.ViewModels;
using CruderSimple.MySql.Entities;
{%if is_multitenant == "True"%}
using CruderSimple.Core.Extensions;
using {{solution_name}}.Domain.Models.Identity;
{%endif%}
using Mapster;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Domain.Models;
{{is_}}
public class {{entity_name}} : {%if is_multitenant == "True"%}{{multitenant_name}}Entity{%else%}Entity{%endif%}
{
    #region Properties

    #endregion

    public override IEntity FromInput(BaseDto input) 
        => this.ParseWithContext<{{entity_name}}, {{entity_name}}Dto>(input);

    public override BaseDto ConvertToOutput()
        => FromOutputBase<{{entity_name}}, {{entity_name}}Dto>();
}