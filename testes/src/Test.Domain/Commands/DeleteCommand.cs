using MediatR;
using Test.Domain.ViewModels.Base;

namespace Test.Domain.Commands;

public class DeleteCommand<IOutputDto> : IRequest<IOutputDto> where IOutputDto : OutputDto 
{
    public string Id { get; set; }

    public DeleteCommand(string id) 
        => Id = id;
}