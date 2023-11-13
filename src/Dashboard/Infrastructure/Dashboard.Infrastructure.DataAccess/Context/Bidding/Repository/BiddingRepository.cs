// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Dashboard.Application.AppServices.Contexts.Bidding.Repositories;
using Dashboard.Contracts;
using Dashboard.Contracts.Bidding;
using Dashboard.Infrastructure.Repository;
using System.Linq.Expressions;
using System;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.DataAccess.Contexts.Bidding.Repositories;

/// <inheritdoc cref="IBiddingRepository"/>
public class BiddingRepository : IBiddingRepository
{
    private readonly IRepository<Domain.Biddings.Bidding> _repository;

    /// <inheritdoc />
    public BiddingRepository(IRepository<Domain.Biddings.Bidding> repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public async Task<Guid> CreateAsync(Domain.Biddings.Bidding model, CancellationToken cancellationToken)
    {
        /*await*/ _repository.AddAsync(model);
        return model.Id;
    }

    /// <inheritdoc />
    public Task<Domain.Biddings.Bidding> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.GetByIdAsync(id, cancellationToken);
    }

    /// <inheritdoc />
    public IQueryable<Domain.Biddings.Bidding> GetAllAsync(CancellationToken cancellationToken)
    {
        return _repository.GetAll();
    }

    /// <inheritdoc />
    public async Task<Domain.Biddings.Bidding> UpdateAsync(Domain.Biddings.Bidding model, CancellationToken cancellationToken)
    {
        /*await*/ _repository.UpdateAsync(model);
        return model;
    }

    /// <inheritdoc />
    public async Task<Guid> DeleteAsync(Domain.Biddings.Bidding model, CancellationToken cancellationToken)
    {
        /*await*/ _repository.DeleteAsync(model);
        return model.Id;
    }
}


