using MediatR;
using {{solution_name}}.Domain.ViewModels.Base;

namespace {{solution_name}}.Domain.Commands;

public class GetByIdCommand<IOutputDto> : IRequest<IOutputDto>
    where IOutputDto : OutputDto 
{
    public string Id { get; set; }

    public GetByIdCommand(string id) 
        => Id = id;
}