using MediatR;
using {{solution_name}}.Domain.ViewModels.Base;

namespace {{solution_name}}.Domain.Commands;

public class CreateCommand<TInputDto, IOutputDto> : IRequest<IOutputDto>
    where TInputDto : InputDto 
    where IOutputDto : OutputDto 
{
    public TInputDto Payload { get; set; }

    public CreateCommand(TInputDto payload) 
        => Payload = payload;
}