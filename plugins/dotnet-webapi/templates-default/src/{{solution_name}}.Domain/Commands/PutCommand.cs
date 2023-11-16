using MediatR;
using {{solution_name}}.Domain.ViewModels.Base;

namespace {{solution_name}}.Domain.Commands;

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