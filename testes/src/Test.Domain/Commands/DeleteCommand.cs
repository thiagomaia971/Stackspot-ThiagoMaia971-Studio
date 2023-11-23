using MediatR;
using Test.Domain.ViewModels.Base;

namespace Test.Domain.Endpoints.Base;

public class DeleteRequest<IOutputDto> : IRequest<IOutputDto> where IOutputDto : OutputDto
{
    public string Id { get; set; }

    public DeleteRequest(string id)
        => Id = id;
}