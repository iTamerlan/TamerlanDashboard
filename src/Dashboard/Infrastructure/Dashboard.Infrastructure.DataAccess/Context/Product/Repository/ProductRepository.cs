// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Dashboard.Application.AppServices.Contexts.Product.Repositories;
using Dashboard.Contracts;
using Dashboard.Contracts.Product;
using Dashboard.Infrastructure.Repository;
using System.Linq.Expressions;
using System;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.DataAccess.Contexts.Product.Repositories;

/// <inheritdoc cref="IProductRepository"/>
public class ProductRepository : IProductRepository
{
    private readonly IRepository<Domain.Products.Product> _repository;

    /// <inheritdoc />
    public ProductRepository(IRepository<Domain.Products.Product> repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public async Task<Guid> CreateAsync(Domain.Products.Product model, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(model);
        return model.Id;
    }

    /// <inheritdoc />
    public Task<Domain.Products.Product> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.GetByIdAsync(id, cancellationToken);
    }

    /// <inheritdoc />
    public IQueryable<Domain.Products.Product> GetAllAsync(CancellationToken cancellationToken)
    {
        return _repository.GetAll();
    }

    /// <inheritdoc />
    public async Task<Domain.Products.Product> UpdateAsync(Domain.Products.Product model, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(model);
        return model;
    }

    /// <inheritdoc />
    public async Task<Guid> DeleteAsync(Domain.Products.Product model, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(model);
        return model.Id;
    }
}


