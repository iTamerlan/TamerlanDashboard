// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Dashboard.Application.AppServices.Contexts.Community.Repositories;
using Dashboard.Contracts;
using Dashboard.Contracts.Community;
using Dashboard.Infrastructure.Repository;
using System.Linq.Expressions;
using System;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.DataAccess.Contexts.Community.Repositories;

/// <inheritdoc cref="ICommunityRepository"/>
public class CommunityRepository : ICommunityRepository
{
    private readonly IRepository<Domain.Communitys.Community> _repository;

    /// <inheritdoc />
    public CommunityRepository(IRepository<Domain.Communitys.Community> repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public async Task<Guid> CreateAsync(Domain.Communitys.Community model, CancellationToken cancellationToken)
    {
        /*await*/ _repository.AddAsync(model);
        return model.Id;
    }

    /// <inheritdoc />
    public Task<Domain.Communitys.Community> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.GetByIdAsync(id, cancellationToken);
    }

    /// <inheritdoc />
    public IQueryable<Domain.Communitys.Community> GetAllAsync(CancellationToken cancellationToken)
    {
        return _repository.GetAll();
    }

    /// <inheritdoc />
    public async Task<Domain.Communitys.Community> UpdateAsync(Domain.Communitys.Community model, CancellationToken cancellationToken)
    {
        /*await*/ _repository.UpdateAsync(model);
        return model;
    }

    /// <inheritdoc />
    public async Task<Guid> DeleteAsync(Domain.Communitys.Community model, CancellationToken cancellationToken)
    {
        /*await*/ _repository.DeleteAsync(model);
        return model.Id;
    }
}

