using MediatR;
using Test.Domain.ViewModels.Base;

namespace Test.Domain.Endpoints.Base;

public class GetAllRequest<IOutputDto> : IRequest<Pagination<IOutputDto>>
    where IOutputDto : OutputDto
{
}