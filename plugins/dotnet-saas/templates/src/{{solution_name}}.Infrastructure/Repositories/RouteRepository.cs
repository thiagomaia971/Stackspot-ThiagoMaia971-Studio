using CruderSimple.Core.Entities;
using CruderSimple.MySql.Repositories;
using Microsoft.EntityFrameworkCore;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.Models.Identity;

namespace {{solution_name}}.Infrastructure.Repositories;

public class RouteRepository(DbContext dbContext, MultiTenantScoped multiTenant)
    : Repository<Route>(dbContext, multiTenant), IRouteRepository;