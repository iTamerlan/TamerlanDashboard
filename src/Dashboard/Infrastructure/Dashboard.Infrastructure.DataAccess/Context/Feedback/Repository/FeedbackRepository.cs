// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Dashboard.Application.AppServices.Contexts.Feedback.Repositories;
using Dashboard.Contracts;
using Dashboard.Contracts.Feedback;
using Dashboard.Infrastructure.Repository;
using System.Linq.Expressions;
using System;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.DataAccess.Contexts.Feedback.Repositories;

/// <inheritdoc cref="IFeedbackRepository"/>
public class FeedbackRepository : IFeedbackRepository
{
    private readonly IRepository<Domain.Feedbacks.Feedback> _repository;

    /// <inheritdoc />
    public FeedbackRepository(IRepository<Domain.Feedbacks.Feedback> repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public async Task<Guid> CreateAsync(Domain.Feedbacks.Feedback model, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(model);
        return model.Id;
    }

    /// <inheritdoc />
    public Task<Domain.Feedbacks.Feedback> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.GetByIdAsync(id, cancellationToken);
    }

    /// <inheritdoc />
    public IQueryable<Domain.Feedbacks.Feedback> GetAllAsync(CancellationToken cancellationToken)
    {
        return _repository.GetAll();
    }

    /// <inheritdoc />
    public async Task<Domain.Feedbacks.Feedback> UpdateAsync(Domain.Feedbacks.Feedback model, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(model);
        return model;
    }

    /// <inheritdoc />
    public async Task<Guid> DeleteAsync(Domain.Feedbacks.Feedback model, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(model);
        return model.Id;
    }
}


