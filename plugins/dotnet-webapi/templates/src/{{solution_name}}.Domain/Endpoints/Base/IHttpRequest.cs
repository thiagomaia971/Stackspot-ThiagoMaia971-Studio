using MediatR;
using {{solution_name}}.Domain.ViewModels.Base;

namespace {{solution_name}}.Domain.Endpoints.Base;

public interface IHttpRequest : IRequest<IResult> 
{
    
}