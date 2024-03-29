// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Dashboard.Application.AppServices.Contexts.Category.Repositories;
using Dashboard.Contracts;
using Dashboard.Contracts.Category;
using Dashboard.Infrastructure.Repository;
using System.Linq.Expressions;
using System;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.DataAccess.Contexts.Category.Repositories;

/// <inheritdoc cref="ICategoryRepository"/>
public class CategoryRepository : ICategoryRepository
{
    private readonly IRepository<Domain.Categorys.Category> _repository;

    /// <inheritdoc />
    public CategoryRepository(IRepository<Domain.Categorys.Category> repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public async Task<Guid> CreateAsync(Domain.Categorys.Category model, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(model);
        return model.Id;
    }

    /// <inheritdoc />
    public Task<Domain.Categorys.Category> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.GetByIdAsync(id, cancellationToken);
    }

    /// <inheritdoc />
    public IQueryable<Domain.Categorys.Category> GetAllAsync(CancellationToken cancellationToken)
    {
        return _repository.GetAll();
    }

    /// <inheritdoc />
    public async Task<Domain.Categorys.Category> UpdateAsync(Domain.Categorys.Category model, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(model);
        return model;
    }

    /// <inheritdoc />
    public async Task<Guid> DeleteAsync(Domain.Categorys.Category model, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(model);
        return model.Id;
    }
}


