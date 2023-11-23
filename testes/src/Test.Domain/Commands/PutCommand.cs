using MediatR;
using Test.Domain.ViewModels.Base;

namespace Test.Domain.Endpoints.Base;

public class PutRequest<TInputDto, IOutputDto> : IRequest<IOutputDto>
    where TInputDto : InputDto
    where IOutputDto : OutputDto
{
    public string Id { get; set; }
    public TInputDto Payload { get; set; }

    public PutRequest(string id, TInputDto payload)
    {
        Id = id;
        Payload = payload;
    }
}