// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Dashboard.Application.AppServices.Contexts.Voting.Repositories;
using Dashboard.Contracts;
using Dashboard.Contracts.Voting;
using Dashboard.Infrastructure.Repository;
using System.Linq.Expressions;
using System;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.DataAccess.Contexts.Voting.Repositories;

/// <inheritdoc cref="IVotingRepository"/>
public class VotingRepository : IVotingRepository
{
    private readonly IRepository<Domain.Votings.Voting> _repository;

    /// <inheritdoc />
    public VotingRepository(IRepository<Domain.Votings.Voting> repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public async Task<Guid> CreateAsync(Domain.Votings.Voting model, CancellationToken cancellationToken)
    {
        /*await*/ _repository.AddAsync(model);
        return model.Id;
    }

    /// <inheritdoc />
    public Task<Domain.Votings.Voting> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.GetByIdAsync(id, cancellationToken);
    }

    /// <inheritdoc />
    public IQueryable<Domain.Votings.Voting> GetAllAsync(CancellationToken cancellationToken)
    {
        return _repository.GetAll();
    }

    /// <inheritdoc />
    public async Task<Domain.Votings.Voting> UpdateAsync(Domain.Votings.Voting model, CancellationToken cancellationToken)
    {
        /*await*/ _repository.UpdateAsync(model);
        return model;
    }

    /// <inheritdoc />
    public async Task<Guid> DeleteAsync(Domain.Votings.Voting model, CancellationToken cancellationToken)
    {
        /*await*/ _repository.DeleteAsync(model);
        return model.Id;
    }
}


