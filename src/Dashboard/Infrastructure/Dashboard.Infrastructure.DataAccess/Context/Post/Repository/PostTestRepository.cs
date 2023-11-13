using Dashboard.Application.AppServices.Contexts.Post.Repositories;
using Dashboard.Contracts;
using Dashboard.Contracts.Post;
using Dashboard.Infrastructure.Repository;

namespace Dashboard.Infrastructure.DataAccess.Contexts.Post.Repositories;

/// <inheritdoc cref="IPostRepository"/>
/*
public class PostTestRepository : IPostRepository
{
    // Expression<Func<Domain.Posts.Post, bool>> predicat = Post => Post;
    // predicat.Parameters(predicat => { });
    private readonly IRepository<Domain.Posts.Post> _repository;

    /// <inheritdoc />
    public PostTestRepository(IRepository<Domain.Posts.Post> repository)
    {
        _repository = repository;
    }

    private readonly List<Domain.Posts.Post> _Posts = new();

    /// <inheritdoc />
    public Task<Domain.Posts.Post> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return Task.Run(() => new Domain.Posts.Post
        {
            Id = Guid.NewGuid(),
            Title = "Тестовое объявление",
            Description = "Описание.",
            CategoryName = "Category",
            //CategoryId = Guid.NewGuid(),
            Price = 500.43M

        }, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Guid> CreateAsync(Domain.Posts.Post model, CancellationToken cancellationToken)
    {
        model.Id = Guid.NewGuid();
        _Posts.Add(model);
        return Task.Run(() => model.Id);
    }

    /// <inheritdoc />
    public Task<Domain.Posts.Post> UpdateAsync(Domain.Posts.Post model, CancellationToken cancellationToken)
    {
        //model.Id = Guid.NewGuid();
        _Posts.Add(model);
        return Task.Run(() => model);
    }

    /// <inheritdoc />
    public Task<Domain.Posts.Post> DeleteAsync(Domain.Posts.Post model, CancellationToken cancellationToken)
    {
        //model.Id = Guid.NewGuid();
        //_Posts.Add(model);
        return Task.Run(() => model);
    }
}*/