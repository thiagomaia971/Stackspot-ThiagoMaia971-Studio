using MediatR;
using Test.Domain.ViewModels.Base;

namespace Test.Domain.Commands;

public class PutCommand<TInputDto, IOutputDto> : IRequest<IOutputDto>
    where TInputDto : InputDto
    where IOutputDto : OutputDto
{
    public string Id { get; set; }
    public TInputDto Payload { get; set; }

    public PutCommand(string id, TInputDto payload)
    {
        Id = id;
        Payload = payload;
    }
}