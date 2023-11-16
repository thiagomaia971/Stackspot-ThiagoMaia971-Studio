using System.Linq.Expressions;
using AutoMapper;
using {{solution_name}}.Domain.ViewModels.Base;

namespace {{solution_name}}.Domain.Models.AutoMappers;

public class AutoMapperBuilder<TEntity, TInputDto, TOutputDto>
    where TEntity : Entity
    where TInputDto : InputDto
    where TOutputDto : OutputDto
{
    private IList<(Expression<Func<TInputDto, string>> inputMap, Expression<Func<TEntity, string>> entityMap)>
        mapsInputToEntity;

    private IList<(Action<IMemberConfigurationExpression<TEntity, TOutputDto, string>> entityMap, Expression<Func<TOutputDto, string>> outputMap)>
        mapsEntityToOutput;

    private readonly IMappingExpression<TInputDto, TEntity> _inputToEntityMap;
    private readonly IMappingExpression<TEntity, TOutputDto> _entityToOutputMap;
    private readonly IMappingExpression<Pagination<TEntity>, Pagination<TOutputDto>> _paginationMap;

    private AutoMapperBuilder(
        IMappingExpression<TInputDto, TEntity> inputToEntityMap, 
        IMappingExpression<TEntity, TOutputDto> entityToOutputMap, 
        IMappingExpression<Pagination<TEntity>, Pagination<TOutputDto>> paginationMap)
    {
        _inputToEntityMap = inputToEntityMap;
        _entityToOutputMap = entityToOutputMap;
        _paginationMap = paginationMap;

        mapsInputToEntity =
            new List<(Expression<Func<TInputDto, string>> inputMap, Expression<Func<TEntity, string>> entityMap)>();
        mapsEntityToOutput =
            new List<(Action<IMemberConfigurationExpression<TEntity, TOutputDto, string>> entityMap, Expression<Func<TOutputDto, string>> outputMap)>();
    }

    public static AutoMapperBuilder<TEntity, TInputDto, TOutputDto> Create(
        IMappingExpression<TInputDto, TEntity> inputToEntityMap,
        IMappingExpression<TEntity, TOutputDto> entityToOutputMap,
        IMappingExpression<Pagination<TEntity>, Pagination<TOutputDto>> paginationMap)
        => new(inputToEntityMap, entityToOutputMap, paginationMap);
        
    public AutoMapperBuilder<TEntity, TInputDto, TOutputDto> AddInputToEntityMap(
        Expression<Func<TInputDto, string>> inputMap, Expression<Func<TEntity, string>> entityMap)
    {
            
        mapsInputToEntity.Add((inputMap, entityMap));
        return this;
    }

    public AutoMapperBuilder<TEntity, TInputDto, TOutputDto> AddEntityToOutputMap(
        Action<IMemberConfigurationExpression<TEntity, TOutputDto, string>> entityMap, Expression<Func<TOutputDto, string>> outputMap)
    {
        mapsEntityToOutput.Add((entityMap, outputMap));
        return this;
    }

    public void Finish()
    {
        foreach (var (inputMap, entityMap) in mapsInputToEntity)
            _inputToEntityMap.ForMember(entityMap, opt => opt.MapFrom(inputMap));

        foreach (var (entityMap, outputMap) in mapsEntityToOutput)
            _entityToOutputMap.ForMember(outputMap, entityMap);
    }
}