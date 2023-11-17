using MediatR;
using {{solution_name}}.Domain.ViewModels.Base;

namespace {{solution_name}}.Domain.Commands;

public class GetAllCommand<IOutputDto> : IRequest<Pagination<IOutputDto>>
    where IOutputDto : OutputDto 
{
}