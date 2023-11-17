using MediatR;
using Test.Domain.ViewModels.Base;

namespace Test.Domain.Commands;

public class CreateCommand<TInputDto, IOutputDto> : IRequest<IOutputDto>
    where TInputDto : InputDto
    where IOutputDto : OutputDto
{
    public TInputDto Payload { get; set; }

    public CreateCommand(TInputDto payload)
        => Payload = payload;
}