using MediatR;
using Test.Domain.ViewModels.Base;

namespace Test.Domain.Endpoints.Base;

public class CreateRequest<TInputDto, IOutputDto> : IRequest<IOutputDto>
    where TInputDto : InputDto
    where IOutputDto : OutputDto
{
    public TInputDto Payload { get; set; }

    public CreateRequest(TInputDto payload)
        => Payload = payload;
}