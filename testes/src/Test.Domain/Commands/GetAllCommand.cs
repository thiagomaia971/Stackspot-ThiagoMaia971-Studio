using MediatR;
using Test.Domain.ViewModels.Base;

namespace Test.Domain.Commands;

public class GetAllCommand<IOutputDto> : IRequest<Pagination<IOutputDto>>
    where IOutputDto : OutputDto 
{
}