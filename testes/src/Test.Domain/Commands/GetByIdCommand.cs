using MediatR;
using Test.Domain.ViewModels.Base;

namespace Test.Domain.Commands;

public class GetByIdCommand<IOutputDto> : IRequest<IOutputDto>
    where IOutputDto : OutputDto
{
    public string Id { get; set; }

    public GetByIdCommand(string id)
        => Id = id;
}