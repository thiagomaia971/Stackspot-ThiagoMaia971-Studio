using MediatR;
using {{solution_name}}.Domain.ViewModels.Base;

namespace {{solution_name}}.Domain.Commands;

public class DeleteCommand<IOutputDto> : IRequest<IOutputDto> where IOutputDto : OutputDto 
{
    public string Id { get; set; }

    public DeleteCommand(string id) 
        => Id = id;
}