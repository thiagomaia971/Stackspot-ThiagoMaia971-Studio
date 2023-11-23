using MediatR;
using Test.Domain.ViewModels.Base;

namespace Test.Domain.Endpoints.Base;

public class GetByIdRequest<IOutputDto> : IRequest<IOutputDto>
    where IOutputDto : OutputDto
{
    public string Id { get; set; }

    public GetByIdRequest(string id)
        => Id = id;
}